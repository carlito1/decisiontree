using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic
{
    public class EventConnection : Connection, IEventConnection
    {
        protected double probability;
        double IEventConnection.GetProbability()
        {
            if (probability <= 0 || probability >= 1)
            {
                throw new ArgumentOutOfRangeException("probability", "Probability must be between 0 and 1");
            }
            return this.probability;
        }
        void IEventConnection.SetProbability(double probability)
        {
            if(probability <= 0 || probability >= 1)
            {
                throw new ArgumentOutOfRangeException("probability","Probability must be between 0 and 1");
            }

            this.probability = probability;
        }
    }
}
