using System;

namespace BlazorEF.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Call save change from db context
        void Commit();
    }
}