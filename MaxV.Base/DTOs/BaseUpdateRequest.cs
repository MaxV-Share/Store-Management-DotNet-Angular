namespace MaxV.Common.Model.DTOs
{
    public abstract class BaseUpdateRequest<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}
