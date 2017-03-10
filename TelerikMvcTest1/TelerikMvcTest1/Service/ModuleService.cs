using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikMvcTest1.Models.ModuleDB;

namespace TelerikMvcTest1.Service
{
    public class ModuleService:IModuleService
    {
        private static bool UpdateDatabase = false;
        private CSADBEntities db;

        public ModuleService (CSADBEntities entities)
        {
            db = entities;
        }
        public List <Module > GetAll()
        {
            List<Module> result = db.Modules.ToList();
            return result;
        }
         public List<Module > Read()
        {
            return GetAll();
        }

        public void Create(Module module)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(e => e.ModuleId).FirstOrDefault();
                var id = (first != null) ? first.ModuleId : 0;

                module.ModuleId = id + 1;

                GetAll().Insert(0, module);
            }
            else
            {
                var entity = new Module();
                entity.ModuleId = module.ModuleId;
                entity.ModuleCode = module.ModuleCode;
                entity.ModuleName = module.ModuleName;
                entity.Status = module.Status;
                entity.CreateDate = DateTime.Today.Date;
                entity.CreateBy = "Admin";
                db.Modules.Add(entity);
                db.SaveChanges();
                module.ModuleId = entity.ModuleId;
            }

        }
    }
}