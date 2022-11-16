using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {

    }
}
