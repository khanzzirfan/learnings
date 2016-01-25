using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories.Tests
{
    // These tests are mostly about behavior. I'm avoiding testing against actual LINQ entities so I'm not
    // leaking real database stuff. 
    [TestClass]
    public class RepositoryBaseTests
    {
        private FakeDataContext fakeDataContext;

        [TestInitialize]
        public void TestInitialize()
        {
            fakeDataContext = new FakeDataContext();
        }

        [TestMethod]
        public void GetAll_returns_all_entities()
        {
            // setup
            var entity1 = new TestEntity() { Name = "A" };
            var entity2 = new TestEntity() { Name = "B" };
            fakeDataContext.Set<TestEntity>().Add(entity1);
            fakeDataContext.Set<TestEntity>().Add(entity2);

            // act
            var results = CreateInstance().GetAll();

            // verify
            Assert.AreEqual(2, results.Count());
            Assert.IsTrue(results.Contains(entity1));
            Assert.IsTrue(results.Contains(entity2));
        }

        [TestMethod]
        public void GetAll_does_not_return_soft_deleted_entities()
        {
            // setup
            var entity1 = new TestEntity() { Name = "A", Deleted = DateTime.Now };
            fakeDataContext.Set<TestEntity>().Add(entity1);

            // act
            var results = CreateInstance().GetAll();

            // verify
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void InsertAndSubmit_saves_a_new_entity_to_datasource()
        {
            // setup
            var newEntity = new TestEntity() { Name = "New entity" };

            // act
            CreateInstance().InsertAndSubmit(newEntity);

            // verify
            Assert.AreEqual(1, fakeDataContext.Set<TestEntity>().Count(p => p.Name == newEntity.Name));
            Assert.IsTrue(fakeDataContext.SaveWasCalled);
        }

        [TestMethod]
        public void UpdateAndSubmit_saves_changes_to_the_datasource()
        {
            // setup
            var entity = new TestEntity() { Name = "entity" };
            fakeDataContext.Set<TestEntity>().Add(entity);

            // act
            entity.Name = "New entity name";
            CreateInstance().UpdateAndSubmit(entity);

            // verify
            Assert.AreEqual(1, fakeDataContext.Set<TestEntity>().Count(p => p.Name == "New entity name"));
            Assert.AreEqual(0, fakeDataContext.Set<TestEntity>().Count(p => p.Name == "entity"));
            Assert.IsTrue(fakeDataContext.SaveWasCalled);
        }

        [TestMethod]
        public void DeleteAndSubmit_deletes_entity_from_the_datasource()
        {
            // setup
            var entity = new TestEntity() { Name = "entity" };
            fakeDataContext.Set<TestEntity>().Add(entity);

            // act
            entity.Name = "New entity name";
            CreateInstance().DeleteAndSubmit(entity);

            // verify
            Assert.IsFalse(fakeDataContext.Set<TestEntity>().Contains(entity));
            Assert.IsTrue(fakeDataContext.SaveWasCalled);
        }

        [TestMethod]
        public void SoftDeleteAndSubmit_marks_deleted_property_on_entity_but_does_not_actually_delete_it()
        {            
            // setup
            var entity = new TestEntity() { Name = "entity" };
            fakeDataContext.Set<TestEntity>().Add(entity);

            // act
            entity.Name = "New entity name";
            CreateInstance().SoftDeleteAndSubmit(entity);

            // verify
            var dbEntity = fakeDataContext.Set<TestEntity>().Single(p => p.Name == entity.Name);
            Assert.IsNotNull(dbEntity);
            Assert.IsNotNull(dbEntity.Deleted);
            Assert.IsTrue(fakeDataContext.SaveWasCalled);
        }

        private TestRepository CreateInstance()
        {
            return new TestRepository(fakeDataContext);
        }
    }
}
