using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerWebAPI.Models
{
    public class Users: Skillset
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
       
    }

    public class Skillset
    {
        public int Id { get; set; }
        public string SkillSet { get; set; }
        public string Hobbies { get; set; }
        public int Freelancer_User_Id { get; set; }

        public int Status
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
    }
}