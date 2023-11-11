using CustomerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Interfaces
{
    public interface  IConfigDetails
    {
               Task<IEnumerable<ConfigDetails>> GetCongDetails();

        //aasda

    }
}
