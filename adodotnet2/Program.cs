// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//         "Data Source=HYPER\\SQLEXPRESS;Initial Catalog=adodotnet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine("connection established");

//                 string query = "GetCollegeDataByNameGender";

//                 using (SqlCommand command = new SqlCommand(query, connection))
//                 {
//                     // telling command it is stored procedure
//                     command.CommandType = CommandType.StoredProcedure;

//                     // adding parameters
//                     command.Parameters.AddWithValue("@Name", "Deepak");
//                     command.Parameters.AddWithValue("@Gender", "Male");

//                     using (SqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             Console.WriteLine(
//                                 $"{reader["Name"]} {reader["Department"]} {reader["Gender"]}");
//                         }
//                     }
//                 }
//             }
//             catch (SqlException ex)
//             {
//                 Console.WriteLine($"Error: {ex.Message}");
//             }
//         }
//     }
// }




//executehnonquery use
// using System;
// using System.Data;
// using Microsoft.Data.SqlClient;

// class Program
// {
    
//     static void Main()
//     {
//         string connectionString =
//         "Data Source=HYPER\\SQLEXPRESS;Initial Catalog=adodotnet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection established");

//                 string query = "UPDATE CollegeMaster1 SET Name = 'sacin' WHERE Name = 'Deepak'";

//                 using (SqlCommand command = new SqlCommand(query, connection))
//                 {
//                     int rowsAffected = command.ExecuteNonQuery();

//                     Console.WriteLine($"Rows updated: {rowsAffected}");
//                 }
//             }
//             catch (SqlException ex)
//             {
//                 Console.WriteLine($"Error: {ex.Message}");
//             }
//         }
//     }
// }





//using executehnonquery,executescaler,executereader

// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//         "Data Source=HYPER\\SQLEXPRESS;Initial Catalog=adodotnet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

//         int tc = 0;

//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             connection.Open();

//             string query = "SELECT COUNT(*) FROM CollegeMaster1";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 tc = (int)command.ExecuteScalar();
//                 Console.WriteLine("Total Head Count: " + tc);
//             }

//             if (tc > 5)
//             {
//                 query = "DELETE FROM CollegeMaster1 WHERE M1 < 50";

//                 using (SqlCommand command = new SqlCommand(query, connection))
//                 {
//                     int nonq = command.ExecuteNonQuery();
//                     Console.WriteLine("Rows Deleted: " + nonq);
//                 }
//             }

//             // Show all records
//             query = "SELECT * FROM CollegeMaster1";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             using (SqlDataReader reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Department"]} {reader["Gender"]} {reader["M1"]}");
//                 }
//             }

            
            
//             string name = "sacin";

//             query = "SELECT * FROM CollegeMaster1 WHERE Name = @name";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@name", name);

//                 using (SqlDataReader reader = command.ExecuteReader())
//                 {
//                     while (reader.Read())
//                     {
//                         Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Department"]} {reader["Gender"]} {reader["M1"]}");
//                     }
//                 }
//             }
//         }
//     }
// }







//disconnected 
using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs =
        "Data Source=HYPER\\SQLEXPRESS;Initial Catalog=adodotnet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        DataSet ds = new DataSet();   // 👉 DataSet create

        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "SELECT Name FROM CollegeMaster1";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            // 👉 DataSet ke andar "Students" naam ka table create karke fill
            adapter.Fill(ds, "Students");

            Console.WriteLine("Names from database:");

            // 👉 Specific table access by name
            foreach (DataRow row in ds.Tables["Students"].Rows)
            {
                Console.WriteLine(row["Name"]);
            }
        }
    }
}

