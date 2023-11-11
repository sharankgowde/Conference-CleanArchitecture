
using CustomerApp.Core.Interfaces;
using CustomerApp.Core.Models;
using Microsoft.Data.SqlClient;

namespace CustomerApp.Infrastructure.SQLData
{
    public class CustomerSQLRepository : ICustomerRepository
    {
        
      
        public async Task<int> AddCustomer(Customer customer)
        {

            // Implementation of adding customer to the database

            return 1;
        }

        public async Task<IEnumerable<Customer>> GetCustomerDetails(IEnumerable<ConfigDetails> configDetails)
        {
            string  connectionstring  = null;

           foreach (ConfigDetails config in configDetails)
            {
                if (configDetails.Any())
                {
                    if(config.Type == "OnPremise")
                    {
                        connectionstring = config.DatabaseConn;
                    }
                }
            }

            
            SqlConnection conn = new
     SqlConnection(connectionstring);


            string sql = "select * from Userdetails";
            var result = new List<Customer>();

            try
            {
                await conn.OpenAsync();
                //  connection.Wait();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Customer userDetails = new Customer();

                            userDetails.Id = reader.GetString(0);
                            userDetails.Username = reader.GetString(1);
                            userDetails.Salary = reader.GetString(2);
                            userDetails.Comments = reader.GetString(3);
                            result.Add(userDetails);

                        }
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return result;
        }
    }
}