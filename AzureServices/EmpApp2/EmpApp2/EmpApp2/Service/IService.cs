using SQLite.Net;
namespace EmpApp2.Service
{
    class IService
    {
    }

    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
