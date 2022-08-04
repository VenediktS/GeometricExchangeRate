using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApiProvider.Interfaces
{
    public interface IExternalApiProviderService
    {
        public T GetExternalApi<T>() where T : class;
    }
}
