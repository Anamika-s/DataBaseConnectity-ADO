// 1st step install package System.Data.SqlClient

// 2nd step
using System.Data.SqlClient;
namespace DataBaseConnectity_ADO
{
    internal class Program1
    {
        static SqlConnection connection;
        static SqlCommand command;

        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                int ch = Menu();
                switch (ch)
                {
                    case 1: GetRecords(); break;
                    case 2:
                        {
                            Console.WriteLine("enter id");
                            int id = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("enter dept");
                            string dept = Console.ReadLine();
                            Console.WriteLine("enter salary");
                            int salary = int.Parse(Console.ReadLine());
                            // Object Initializer
                            Employee employee = new Employee()
                            {
                                Id = id,
                                Name = name,
                                Dept = dept,
                                Salary = salary
                            };
                            AddRecord(employee); break;
                        }
                    case 3:
                        {
                            Console.WriteLine("enter id for which to delete record");
                            int id = byte.Parse(Console.ReadLine());
                            DeleteRecord(id); break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter id for which to edit record");
                            int id = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter new dept");
                            string dept = Console.ReadLine();
                            Console.WriteLine("enter updated salary");
                            int salary = int.Parse(Console.ReadLine());
                            Employee employee = new Employee()
                            {
                                Id = id,
                                Dept = dept,
                                Salary = salary
                            };
                            EditRecord(id, employee); break;

                        }
                    default:
                        Console.WriteLine("invalid choice"); break;
                }

                Console.WriteLine("Repeat?");
                choice = Console.ReadLine();
            }
        }
        static string GetConnectionString()
        {
            //\n\t
            return @"server=ANAMIKA\SQLSERVER;database=wiproDb;integrated security=true";
        }
        static SqlConnection GetConnection()
        {
            connection = new SqlConnection(GetConnectionString());
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
            //string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
            //  "integrated security=true";
            //connection = new SqlConnection(connectionString);
            connection = GetConnection();
            command = new SqlCommand();
            command.CommandText = "select * from employee";
            command.Connection = connection;

            // step 5

            connection.Open();  // this will establish between console app & database

            // step 4
            // run the query
            //Console.BackgroundColor = ConsoleColor.Green;
            
            //Console.WriteLine("LIST");
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader[0] + " " + reader["name"] + " " + reader[2]);
                //}
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine("");
                }
            }
            else
            {

                Console.WriteLine("there are no records");
            }
            reader.Close();
            connection.Close();
        }
        static void AddRecord(Employee employee)
        {
            //string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
            //  "integrated security=true";
            //connection = new SqlConnection(connectionString);
            connection = GetConnection();
            command = new SqlCommand();
            command.CommandText = "insert into employee(id, name, dept, salary) values (@id, @name, @dept, @salary)";
            command.Parameters.AddWithValue("@id", employee.Id);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@dept", employee.Dept);
            command.Parameters.AddWithValue("@salary", employee.Salary);
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }


        static void DeleteRecord(int id)
        {
            //string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
            //  "integrated security=true";
            //connection = new SqlConnection(connectionString);
            connection = GetConnection();
            command = new SqlCommand();
            command.CommandText = "delete from employee where id=@id";
            command.Parameters.AddWithValue("@id", id);
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }

        static void EditRecord(int id, Employee employee)
        {
            //string connectionString = "server=ANAMIKA\\SQLSERVER;database=wiproDb;" +
            //  "integrated security=true";
            //connection = new SqlConnection(connectionString);
            connection = GetConnection();
            command = new SqlCommand();
            command.CommandText = "update employee set salary=@salary, dept= @dept where id=@id";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@dept", employee.Dept);
            command.Parameters.AddWithValue("@salary", employee.Salary);
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }
    }
}