namespace App.Common.Model.DTOs
{
    public abstract class BaseUpdateRequest<TKey> : BaseDTO
    {
        public virtual TKey Id { get; set; }
    }
}
