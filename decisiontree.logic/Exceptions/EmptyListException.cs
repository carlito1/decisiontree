using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Exceptions
{
    public class EmptyListException : Exception
    {
        public string Atribute { get; set; }
        public EmptyListException(string message, string atribute) : base(message)
        {
            this.Atribute = atribute;
        }
    }
}
