using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Interfaces
{
    public interface IEventConnection : IConnection
    {
        double GetProbability();
        void SetProbability(double probability);
    }
}
