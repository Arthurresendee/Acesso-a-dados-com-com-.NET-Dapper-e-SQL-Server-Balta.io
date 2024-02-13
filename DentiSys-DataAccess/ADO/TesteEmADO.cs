//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//class Program
//{
//    static void Main()
//    {
//        var connectionString = "Server=localhost;Database=DB_DentiSys_DataAcces;User ID=sa;Password=root; TrustServerCertificate=true";

//        using (var connection = new SqlConnection(connectionString))
//        {
//            connection.Open();

//            ListPatients(connection);

//            //CreatePatient(connection);
//        }
//    }

//    static void ListPatients(SqlConnection connection)
//    {
//        var patientsList = new List<Patient>();

//        string query = "SELECT * FROM PATIENTS";

//        using (SqlCommand command = new SqlCommand(query, connection))
//        {
//            using (SqlDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    var patient = new Patient()
//                    {
//                        Id = (Guid)reader["Id"],
//                        Name = (string)reader["Name"],
//                        Age = (int)reader["Age"],
//                        Height = (double)reader["Height"],
//                        weight = (double)reader["Weight"]
//                    };

//                    patientsList.Add(patient);
//                }
//            }
//        }

//        foreach (var item in patientsList)
//        {
//            Console.WriteLine($"{item.Name} - {item.Age} - {item.Height} - {item.weight}");
//        }
//    }

//    static void CreatePatient(SqlConnection connection)
//    {
//        var patient = new Patient()
//        {
//            Id = Guid.NewGuid(),
//            Name = "Flavin do Pneu",
//            Age = 19,
//            Height = 1.85,
//            weight = 59
//        };

//        var insertPatients = @"insert into 
//            [Patients] 
//        VALUES (
//            @IdParam,
//            @NameParam,
//            @AgeParam,
//            @HeightParam,
//            @WeightParam)";

//        using (SqlCommand command = new SqlCommand(insertPatients, connection))
//        {
//            command.Parameters.AddWithValue("@IdParam", patient.Id);
//            command.Parameters.AddWithValue("@NameParam", patient.Name);
//            command.Parameters.AddWithValue("@AgeParam", patient.Age);
//            command.Parameters.AddWithValue("@HeightParam", patient.Height);
//            command.Parameters.AddWithValue("@WeightParam", patient.weight);

//            // retorna a quantidade de linhas afetadas
//            var rows = command.ExecuteNonQuery();
//            Console.WriteLine($"{rows} linhas inseridas");
//        }
//    }
//}

//class Patient
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public double Height { get; set; }
//    public double weight { get; set; }
//}
