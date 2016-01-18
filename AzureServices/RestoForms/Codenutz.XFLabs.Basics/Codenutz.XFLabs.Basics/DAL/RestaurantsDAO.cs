using Codenutz.XFLabs.Basics.Contracts;
using SQLite.Net.Attributes;

namespace Codenutz.XFLabs.Basics.DAL
{
    public class RestaurantsDAO : IBusinessEntity
    {
        public RestaurantsDAO() { }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Indexed]
        public int StoreId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}
