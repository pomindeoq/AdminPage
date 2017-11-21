using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models.Items
{
    public class CreateItemsResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<int> ItemIds { get; set; }
    }
}
