using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSystem.Entity.Models
{
    public partial class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool changePassword { get; set; }
    }
}
