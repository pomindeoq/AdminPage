using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{    
    public class UserResponse 
    {
        public IEnumerable<string> Errors { get; set; }
        public User User { get; set; }
    }   
}
