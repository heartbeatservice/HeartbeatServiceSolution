using System.Collections.Generic;
using System.Web.Mvc;
using HBS.Data.Entities.SchedulingTimeTracking.Models;
using HBS.Data.Entities.SchedulingTimeTracking.EF;
using System.Linq;


namespace HBS.Data.Entities.SchedulingTimeTracking.Models
{
    public class UserList
    {
        public string SelectedValue { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        public UserList(string selectedValue, int companyId)
        {
            using (var dbContext = new SchTimeTrackingEntities())
            {
                var ulist = dbContext.UserProfiles.Where(c => c.CompanyId.Equals(companyId));

                SelectedValue = selectedValue;
                List<HBS.Entities.UserProfile> userprofile = new List<HBS.Entities.UserProfile>();
                foreach (UserProfile item in ulist)
                {
                    userprofile.Add(new HBS.Entities.UserProfile(item.CompanyId, item.UserName, item.Password, item.FirstName, item.LastName, item.Email, item.UserId, (item.RoleId.HasValue ? item.RoleId.Value : 0)));
                }
                //List<SelectListItem> items = new List<SelectListItem>();
                //foreach (var item in userprofile)
                //{
                //    if (SelectedValue.Equals(item.UserName))
                //    {
                //        items.Add(new SelectListItem() { Text = item.UserName, Value = item.UserId.ToString(), Selected = true });
                //    }
                //    else
                //        items.Add(new SelectListItem() { Text = item.UserName, Value = item.UserId.ToString() });
                //}
                if (!string.IsNullOrEmpty(SelectedValue))
                    Users = new SelectList(userprofile, "UserId", "UserName", selectedValue);
                else
                    Users = new SelectList(userprofile, "UserId", "UserName");
                //Users = items
            }
        }
    }
}
