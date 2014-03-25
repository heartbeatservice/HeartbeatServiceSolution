using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    class ConfigValues:BaseEntity
    {

        public int ConfigId { get; set; }
        public int CompanyId { get; set; }
        public string ControlKey { get; set; }
        public string ControlValue { get; set; }
        public float ControlOrder { get; set; }
        public string ControlItemKey { get; set; }
        public string ControlItemValue { get; set; }
        public string ControlItemText { get; set; }
        public float ControlItemOrder { get; set; }
        public string OtherText { get; set; }

        public ConfigValues()
        { }

        public ConfigValues(IDataReader dbReader)
            : this()
        {

            if (dbReader.HasColumn("ConfigId") && dbReader["ConfigId"] != DBNull.Value)
                ConfigId = (int)dbReader["ConfigId"];
            if (dbReader.HasColumn("CompanyId") && dbReader["CompanyId"] != DBNull.Value)
                CompanyId = (int)dbReader["CompanyId"];
            if (dbReader.HasColumn("ControlKey") && dbReader["ControlKey"] != DBNull.Value)
                ControlKey = (string)dbReader["ControlKey"];
            if (dbReader.HasColumn("ControlValue") && dbReader["ControlValue"] != DBNull.Value)
                ControlValue = (string)dbReader["ControlValue"];
            if (dbReader.HasColumn("ControlOrder") && dbReader["ControlOrder"] != DBNull.Value)
                ControlOrder = (float)dbReader["ControlOrder"];
            if (dbReader.HasColumn("ControlItemKey") && dbReader["ControlItemKey"] != DBNull.Value)
                ControlItemKey = (string)dbReader["ControlItemKey"];
            if (dbReader.HasColumn("ControlItemValue") && dbReader["ControlItemValue"] != DBNull.Value)
                ControlItemValue = (string)dbReader["ControlItemValue"];
            if (dbReader.HasColumn("ControlItemText") && dbReader["ControlItemText"] != DBNull.Value)
                ControlItemText = (string)dbReader["ControlItemText"];
            if (dbReader.HasColumn("ControlItemOrder") && dbReader["ControlItemOrder"] != DBNull.Value)
                ControlItemOrder = (float)dbReader["ControlItemOrder"];
            if (dbReader.HasColumn("OtherText") && dbReader["OtherText"] != DBNull.Value)
                OtherText = (string)dbReader["OtherText"];
            if (dbReader.HasColumn("CreatedBy") && dbReader["CreatedBy"] != DBNull.Value)
                base.CreatedBy = (int)dbReader["CreatedBy"];
            if (dbReader.HasColumn("UpdatedBy") && dbReader["UpdatedBy"] != DBNull.Value)
                base.UpdatedBy = (int)dbReader["UpdatedBy"];
            if (dbReader.HasColumn("DateCreated") && dbReader["DateCreated"] != DBNull.Value)
                base.DateCreated = (DateTime)dbReader["DateCreated"];
            if (dbReader.HasColumn("DateUpdated") && dbReader["DateUpdated"] != DBNull.Value)
                base.DateUpdated = (DateTime)dbReader["DateUpdated"];

        }
    }
}
