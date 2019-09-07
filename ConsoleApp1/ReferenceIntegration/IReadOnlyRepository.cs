using System;
using System.Collections.Generic;
using System.Text;

namespace ReferenceIntegration
{
    public interface IReadOnlyRepository<T> where T: Entity
    {
        T Find(string id);

        IEnumerable<T> ListAll();
    }
}
