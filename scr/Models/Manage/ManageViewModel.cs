using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class ManageViewModel
    {
        
        
            //UserInfo
            public string Username { get; set; }

            public double UserPoints { get; set; }

            public string Email { get; set; }
        
            
            //CreateItem
            public string UserId { get; set; }
           
            //public string Username { get; set; }

            public string Error { get; set; }

            public IEnumerable<SelectListItem> ItemCategories { get; set; }

            public double PointValue { get; set; }

            public string SelectedValue { get; set; }
        
    
            //ManagePoints
            public double Points { get; set; }

            public double Price { get; set; }      
       
            //Checkout
            public int ItemId { get; set; }

            public string NewOwnerAccountUserName { get; set; }

            //public double PointValue { get; set; }
        
    }

}

