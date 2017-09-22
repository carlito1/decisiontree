using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Interfaces
{
    public interface INode
    {
        double GetValue();
        void SetName(string name);
        string GetName();
    }
}
