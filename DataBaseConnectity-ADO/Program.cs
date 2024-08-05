// 1st step install package System.Data.SqlClient

// 2nd step
using System.Data.SqlClient;
namespace DataBaseConnectity_ADO
{
    internal class Program
    {
        static SqlConnection connection;
        static SqlCommand command;

        static void Main(string[] args)
        {
            int ch = Menu();
            switch(ch)
            {
                case 1: GetRecords(); break;
                case 2:  AddRecord(); break;
                case 3:  DeleteRecord(); break;
                case 4: EditRecord(); break;
                default:
                    Console.WriteLine("invalid choice"); break;
            }
        }
        static SqlConnection GetConnection()
        {
            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
              "integrated security=true";
            connection = new SqlConnection(connectionString);
            return connection;
        }

        static int Menu()
        {
            Console.WriteLine("1. Get Records");
            Console.WriteLine("2. Insert Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Edit Record");
            Console.WriteLine("enter your choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }

        static void GetRecords()
        {
            // step 4
            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
              "integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "select * from employee";
            command.Connection = connection;

            // step 5

            connection.Open();  // this will establish between console app & database

            // step 4
            // run the query
            SqlDataReader reader = command.ExecuteReader();
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
        static void AddRecord()
        {
            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
              "integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "insert into employee values (2,'Deepak','HR',9000)";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }


        static void DeleteRecord()
        {
            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
              "integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "delete from employee where id=1";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }

        static void EditRecord()
        {
            string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
              "integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "update employee set salary=50000 where id=1";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }

    }














    // }
}
 