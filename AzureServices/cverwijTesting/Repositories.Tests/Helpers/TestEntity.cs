using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace ChristiaanVerwijs.MvcSiteWithEntityFramework.Repositories.Tests
{
    public class TestEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Deleted { get; set; }
        public string Name { get; set; }
    }
}
