using Npgsql;
using System;
using program;
namespace loginAndRegistration.Models

{
    public class RegistrationClass
    {


        public static async Task insertData() {
            NpgsqlConnection conn =   Program.StartConnection;
            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open) {
                Console.WriteLine("Connected to database");
            }
            
            var insertQuery = "Insert into mvc.user(name,surname,city,zip_code,phone_number) values('Neeraj','Tripathi','Pune','411017','7447553161')";
            await using var insert_cmd = new NpgsqlCommand(insertQuery, conn);
            await insert_cmd.ExecuteNonQueryAsync();
            //var command = "Select * from mvc.user";
            // await using var cmd = new NpgsqlCommand(command, conn);
            //using var reader =  await cmd.ExecuteReaderAsync();
            // while (await reader.ReadAsync()) {
            // Console.WriteLine(reader.GetString(0));
            //}
        }


    }
}
