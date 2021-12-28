using System;
using System.ComponentModel.DataAnnotations;
using App.Common.Model;

namespace App.Models.Entities
{
    public class Customer : BaseEntity<int>
    {
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(256)]
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
