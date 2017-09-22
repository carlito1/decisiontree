using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic
{
    public class Node : INode, ILeaf
    {
        private string name;
        protected List<IConnection> children;
        protected double value;
        public Node()
        {
            children = new List<IConnection>();
        }
        double INode.GetValue()
        {
            return this.value;
        }

        void ILeaf.SetValue(double value)
        {
            this.value = value;
        }
        
        void INode.SetName(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException();
            }
            this.name = name;
        }

        string INode.GetName()
        {
            return name;
        }


    }
}
