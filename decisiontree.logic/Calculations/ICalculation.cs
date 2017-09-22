using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Calculations
{
    public interface ICalculation
    {
        double Calculate(List<IConnection> nodes);
    }
}
