using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models.Points
{
    public class AddPointsResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Succeeded { get; set; }

        public AddPointsResponse()
        {
            Succeeded = false;
            Errors = null;
        }
    }
}
