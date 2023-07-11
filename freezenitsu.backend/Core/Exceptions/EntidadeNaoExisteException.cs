using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class EntidadeNaoExisteException : Exception
    {

        public EntidadeNaoExisteException()
        {
            
        }

        public EntidadeNaoExisteException(string mensagem) : base (mensagem)
        {
            
        }
    }
}
