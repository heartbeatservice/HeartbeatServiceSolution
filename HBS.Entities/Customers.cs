using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBS.Entities.Utilities;
using System.Data;

namespace HBS.Entities
{
    class Customers:BaseEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }   //TODO: we already have Created by in base class so why we need user ID here? 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //TODO:  public string MiddleInitial {get; set;}   //missing from table. 
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }

        public Customers()
        {
        }

         public Customers(IDataReader dbReader)
            : this()
        {
            if (dbReader.HasColumn("CustomerId") && dbReader["CustomerId"] != DBNull.Value)
                CustomerId = (int)dbReader["CustomerId"];
            if (dbReader.HasColumn("UserId") && dbReader["UserId"] != DBNull.Value)
                CustomerId = (int)dbReader["UserId"];
            if (dbReader.HasColumn("FirstName") && dbReader["FirstName"] != DBNull.Value)
                FirstName = (string)dbReader["FirstName"];

            if (dbReader.HasColumn("LastName") && dbReader["LastName"] != DBNull.Value)
                LastName = (string)dbReader["LastName"];
            if (dbReader.HasColumn("Address1") && dbReader["Address1"] != DBNull.Value)
                Address1 = (string)dbReader["Address1"];
            if (dbReader.HasColumn("Address2") && dbReader["Address2"] != DBNull.Value)
                Address2 = (string)dbReader["Address2"];

            if (dbReader.HasColumn("City") && dbReader["City"] != DBNull.Value)
                City = (string)dbReader["Address2"];
            if (dbReader.HasColumn("State") && dbReader["State"] != DBNull.Value)
                State =(string)dbReader["State"];
            if (dbReader.HasColumn("Zip") && dbReader["Zip"] != DBNull.Value)
                Zip = (string)dbReader["Zip"];

            if (dbReader.HasColumn("HomePhone") && dbReader["HomePhone"] != DBNull.Value)
                HomePhone = (string)dbReader["HomePhone"];
            if (dbReader.HasColumn("CellPhone") && dbReader["CellPhone"] != DBNull.Value)
                CellPhone = (string)dbReader["CellPhone"];
            
            
        }


    }
}
