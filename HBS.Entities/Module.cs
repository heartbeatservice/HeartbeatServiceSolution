using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;

namespace HBS.Entities
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string  ModuleDescription { get; set; }
        public int DisplayOrder { get; set; }
        public string ModuleURL { get; set; }
        public bool IsForAll { get; set; }
        public int ParentId { get; set; }
        public string IconName { get; set; }
        public List<Module> SubModule { get; set; }
        public Module()
            : base() { }
        public Module(IDataReader dbReader)
            : base()
        {
            if (dbReader.HasColumn("ModuleId") && dbReader["ModuleId"] != DBNull.Value)
                ModuleId = (int)dbReader["ModuleId"];

            if (dbReader.HasColumn("ModuleName") && dbReader["ModuleName"] != DBNull.Value)
                ModuleName = (string)dbReader["ModuleName"];

            if (dbReader.HasColumn("ModuleDescription") && dbReader["ModuleDescription"] != DBNull.Value)
                ModuleDescription = (string)dbReader["ModuleDescription"];

            if (dbReader.HasColumn("DisplayOrder") && dbReader["DisplayOrder"] != DBNull.Value)
                DisplayOrder = (int)dbReader["DisplayOrder"];

            if (dbReader.HasColumn("ModuleURL") && dbReader["ModuleURL"] != DBNull.Value)
                ModuleURL = (string)dbReader["ModuleURL"];

            if (dbReader.HasColumn("IsForAll") && dbReader["IsForAll"] != DBNull.Value)
                IsForAll = (bool)dbReader["IsForAll"];

            if (dbReader.HasColumn("ParentId") && dbReader["ParentId"] != DBNull.Value)
                ParentId = (int)dbReader["ParentId"];

            if (dbReader.HasColumn("IconName") && dbReader["IconName"] != DBNull.Value)
                IconName = (string)dbReader["IconName"];

        }
    }
}
