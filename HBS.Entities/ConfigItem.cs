using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBS.Entities
{
    public class ControlConfig
    {
        public int ConfigId { get; set; }
        public int CompnayId { get; set; }
        public string CompnayName { get; set; }
        public string ControlKey { get; set; }
        public string ControlValue { get; set; }
        public float ControlOrder { get; set; }
        public List<ControlConfigItem> ControlConfigItemList { get; set; }
        public string OtherText { get; set; }

        public ControlConfig()
        {
            ControlConfigItemList = new List<ControlConfigItem>();
        }
    }
}
