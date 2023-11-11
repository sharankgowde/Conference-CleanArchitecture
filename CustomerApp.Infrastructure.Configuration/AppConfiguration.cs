    using CustomerApp.Core.Interfaces;
    using CustomerApp.Core.Models;

    using Microsoft.Data.SqlClient;

    namespace CustomerApp.Infrastructure.Configuration
    {
        public class AppConfiguration : IConfigDetails
        {

            SqlConnection conn = new
          SqlConnection("Server=tcp:dbservertest-1.database.windows.net,1433;Initial Catalog=CustomerDb;Persist Security Info=False;User ID=sharankgowde;Password=satyam123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            public async Task<IEnumerable<ConfigDetails>> GetCongDetails()
            {
                string sql = "select * from tblConfig";
                var result = new List<ConfigDetails>();

                    await conn.OpenAsync();
               
                   using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                            ConfigDetails Configdata = new ConfigDetails();

                                Configdata.id = reader.GetInt32(0);
                                Configdata.Type = reader.GetString(1);
                                Configdata.DatabaseConn = reader.GetString(2);
                                Configdata.ObservabilityConn = reader.GetString(3);
                                Configdata.DatabaseName = reader.IsDBNull(4) ? string.Empty : reader.GetString(4); 
                                Configdata.ContainerName = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                                result.Add(Configdata);

                            }
                        }
                    }
                                 
                return result;
            }
        }
    }