namespace BlazorEF.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        public T Id { get; set; }

        // True if domain entity has an identity
        public bool IsTransient() => Id.Equals(default(T));
    }
}