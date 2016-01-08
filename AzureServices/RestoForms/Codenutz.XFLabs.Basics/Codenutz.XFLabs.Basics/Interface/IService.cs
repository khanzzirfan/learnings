using SQLite.Net;

namespace Codenutz.XFLabs.Basics.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
