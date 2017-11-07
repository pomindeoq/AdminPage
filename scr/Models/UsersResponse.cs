using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class UsersResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
