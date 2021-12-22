using System.Collections.Generic;
using MaxV.Common.Model.DTOs;

namespace MaxV.Common.Model.DTOs
{
    public interface IBaseTreeViewModel<T>
    {
        public T Data { get; set; }
        public List<IBaseTreeViewModel<T>> Children { get; set; }
    }
}
