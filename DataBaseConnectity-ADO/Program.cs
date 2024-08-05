// 1st step install package System.Data.SqlClient

// 2nd step
using System.Data.SqlClient;
namespace DataBaseConnectity_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3 step

            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
                "integrated security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            // step 4
            SqlCommand command = new SqlCommand();
            command.CommandText = "select * from employee";
            command.Connection = connection;

            // step 5

            connection.Open();  // this will establish between console app & database

            // step 4
            // run the query
            SqlDataReader reader =  command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                }
            }
            else
            {

                Console.WriteLine("there are no records");
            }
            reader.Close();
            connection.Close();
            }
















            // }
        }
}
