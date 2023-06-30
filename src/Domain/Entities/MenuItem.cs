/*
 * File Name : MenuItem.cs
 * class Name : MenuItem
 * Created Date : 23rd Oct 2019
 * Created By : Ritika lath
 * Description : model class to get all the linkPermission provided to a user
 */

namespace SRIS.Domain.Entities
{
    public class MenuItem
    {
        public int intId { get; set; }
        public string vch_name { get; set; }
        public string vch_faicon { get; set; }
        public string vch_url { get; set; }
        public string vch_class { get; set; }
        public string vch_plink_class { get; set; }
        public int int_parent_id { get; set; }
        public int int_slno { get; set; }
        public int catagory { get; set; }
        public string catagoryname { get; set; }
        public string strController { get; set; }
        public string strAction { get; set; }
        public string strArea { get; set; }
        public string categoryclass { get; set; }

    }
}
