using System.Data.SqlClient;

namespace AdoTestStuff
{
    internal class Program
    {
        public static string trustedConnectionString = "Server=207-9;Database=hwdb;Trusted_Connection=True;";
        public static string ConnectionString = " Server=myServerAddress;Database=myDataBase;User Id = user1; Password=useruser;";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(trustedConnectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student", connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string lastName = reader.GetString(1);
                        DateTime birthDate = reader.GetDateTime(2);

                        Console.WriteLine($"ID: {id}, Last Name: {lastName}, Birth Date: {birthDate.ToShortDateString()}");
                    }
                }
            }
        }
    }
}
//CREATE TABLE Student (
//    id INT PRIMARY KEY,
//    last_name NVARCHAR(255),
//    birth_date DATE
//);

//INSERT INTO Student (id, last_name, birth_date) VALUES
//(1, 'Smith', '2000-01-15'),
//(2, 'Johnson', '1999-05-20'),
//(3, 'Williams', '2001-08-10'),
//(4, 'Jones', '1998-03-25'),
//(5, 'Brown', '2002-12-05');