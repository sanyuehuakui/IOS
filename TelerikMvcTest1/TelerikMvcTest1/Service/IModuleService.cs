using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikMvcTest1.Models.ModuleDB;

namespace TelerikMvcTest1.Service
{
    interface IModuleService
    {
       List<Module> Read();
    }
}
