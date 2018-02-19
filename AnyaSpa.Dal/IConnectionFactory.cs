using System.Data.SqlClient;

namespace AnyaSpa.Dal
{
    public interface IConnectionFactory
    {
        SqlConnection OpenAnyaSpaConnection();
    }
}
