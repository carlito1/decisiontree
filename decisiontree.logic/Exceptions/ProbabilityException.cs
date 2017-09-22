using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Exceptions
{
    public class ProbabilityException : Exception
    {
        public double Probability { get; private set; }
        public double MissedProbability
        {
            get { return 1 - Probability; }
        }
        public ProbabilityException(double probability)
            : base(String.Format("Probability is {0}, but it should be 1.0", probability))
        {
            this.Probability = probability;
        }
    }
}
