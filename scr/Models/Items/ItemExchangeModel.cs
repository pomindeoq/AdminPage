using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models.Items
{
    public class ItemExchangeModel
    {
        public int ItemId { get; set; }
        public string NewOwnerAccountId { get; set; }
        public double PointValue { get; set; }
    }
}
