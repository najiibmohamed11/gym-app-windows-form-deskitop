using System.Data.SqlClient;

namespace gym_management_system
{
    class Conclass
    {
        public SqlConnection connect()
        {
            string connectionString = "Data Source=DESKTOP-KJ2NJQE\\SQLEXPRESS;Initial Catalog=GYM;Integrated Security=True;";
            //sql string
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;

        }
    }
}
