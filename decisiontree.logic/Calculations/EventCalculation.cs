using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Calculations
{
    public class EventCalculation : ICalculation
    {
        double value;
        double probability;
        double ICalculation.Calculate(List<Interfaces.IConnection> nodes)
        {
            // For every calculation we start with empty data
            this.value = 0;
            this.probability = 0;
            foreach(IEventConnection connection in nodes)
            {
                value += connection.GetProbability() * connection.GetEndPoint().GetValue();
                probability += connection.GetProbability();
            }

            if(probability != 1)
            {
                throw new ProbabilityException(this.probability);
            }

            return this.value;
        }
    }
}
