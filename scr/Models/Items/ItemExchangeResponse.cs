using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models.Items
{
    public class ItemExchangeResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Succeeded { get; set; }

        public ItemExchangeResponse()
        {
            Errors = null;
            Succeeded = false;
        }
    }
}
