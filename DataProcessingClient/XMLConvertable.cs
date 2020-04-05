using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingClient
{
    public interface XMLConvertable<Tsub>
    {
        Tsub[] GetArray();       
    }
}
