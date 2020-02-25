using System;
using System.Collections.Generic;
using System.Text;

namespace PyxisBackend.Contracts.Models
{
    public interface IRepositoryWrapperPersonPet
    {
        IPersonRepository Person { get; }
        IPetRepository Pet { get; }
        void Save();
    }
}
