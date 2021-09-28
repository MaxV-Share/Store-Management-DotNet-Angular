using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DTOs
{
    public class CustomerCreateRequest
    {
        [JsonProperty(PropertyName = "phoneNumber", Required = Required.Always)]
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
