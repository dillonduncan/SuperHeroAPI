using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models.response
{
    public class LoginResponse
    {
        public String Token { get; set; }
        public SuperHeroResponse SuperHero { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean status {  get; set; }
    }
}