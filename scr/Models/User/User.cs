using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class User
    {
        [JsonProperty("UserId")]
        public string Id { get; set; }
        [JsonProperty("UserName")]
        public string Name { get; set; }
        [JsonProperty("UserEmail")]
        public string Email { get; set; }
        [JsonProperty("UserPoints")]
        public double Points { get; set; }
    }
}
