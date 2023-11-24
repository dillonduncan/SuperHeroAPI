using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class LoginRequest
    {
        public String Heroname {  get; set; }
        public String Password { get; set; }
    }
}