using System;
using App.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class CustomerViewModel : BaseViewModel<int>
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
