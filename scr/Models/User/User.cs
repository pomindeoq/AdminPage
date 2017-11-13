using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPage.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string Id { get; set; }
        [JsonProperty("userName")]
        public string Name { get; set; }
        [JsonProperty("userEmail")]
        public string Email { get; set; }
        [JsonProperty("userPoints")]
        public double Points { get; set; }
    }
}
