using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class IndexViewModel
    {
        public int UserId { get; set; }

        public int BarcodeId { get; set; }

        public int Username { get; set; }

        public IEnumerable<SelectListItem> Usernames { get; set; }

        public string SelectedValue { get; set; }
    }

}
