using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionTree.Logic.Interfaces
{
    public interface IConnection
    {
        void AddEndPoint(INode node);
        INode GetEndPoint();
    }
}
