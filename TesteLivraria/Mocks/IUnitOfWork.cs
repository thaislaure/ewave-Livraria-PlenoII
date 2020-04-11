using System;
using System.Collections.Generic;
using System.Text;

namespace TesteLivraria.Mocks
{
    public interface IUnitOfWork
    { 
        void Commit();
        bool Sucesso();
    }
}
