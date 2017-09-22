using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTree.Logic;

namespace DecisionTree.Logic.Interfaces
{
    public interface IDecisionNode : INode
    {
        void CalculateValue();
        void AddNode(IConnection connection);
        Type GetType();
    }
}
