using System;

namespace App.Common.Model.DTOs
{
    public abstract class BaseViewModel<TKey> : BaseDTO
    {
        public virtual TKey Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
