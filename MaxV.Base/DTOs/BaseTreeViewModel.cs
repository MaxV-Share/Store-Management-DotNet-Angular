using System.Collections.Generic;
using App.Common.Model.DTOs;

namespace App.Common.Model.DTOs
{
    public interface IBaseTreeViewModel<T>
    {
        public T Data { get; set; }
        public List<IBaseTreeViewModel<T>> Children { get; set; }
    }
}
