using Newtonsoft.Json;
using System;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class CustomerCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "phoneNumber", Required = Required.Always)]
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
