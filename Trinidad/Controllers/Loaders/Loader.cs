using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinidad.Models;

namespace Trinidad.Controllers.Loaders
{
    public interface ILoader
    {
        Configuration LoadConfiguration(String adress);
    }
}
