using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic.Calculations
{
    public class DecisionCalculation : ICalculation
    {
        double maximum;
        double ICalculation.Calculate(List<Interfaces.IConnection> nodes)
        {
            if(nodes.Count == 0)
            {
                throw new EmptyListException("Nodes cannot be empty", "nodes");
            }

            this.maximum = nodes[0].GetEndPoint().GetValue();
            for (int i = 1; i < nodes.Count;i++ )
            {
                if(maximum <= nodes[i].GetEndPoint().GetValue())
                {
                    this.maximum = nodes[i].GetEndPoint().GetValue();
                }
            }
            return this.maximum;
        }
    }
}
