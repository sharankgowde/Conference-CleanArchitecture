using CustomerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Interfaces
{
    public interface ICustomLogger
    {
        Task LogInformation(IEnumerable<ConfigDetails> configDetails, string message);
        Task LogError(IEnumerable<ConfigDetails> configDetails,string message, Exception ex);
    }
}
