using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Interfaces
{
    public interface ISecretStorage
    {
        string GetSecret(string keyVaultName,string secretName);
    }
}
