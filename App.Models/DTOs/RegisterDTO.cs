using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [JsonProperty("sss")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
