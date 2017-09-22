using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic
{
    public enum Type { Decision, Event};
    public class DecisionNode : Node, IDecisionNode
    {
        protected ICalculation calculation;

        public DecisionNode(ICalculation calculation)
            : base()
        {
            if(calculation == null)
            {
                throw new ArgumentNullException("calculation");
            }
            this.calculation = calculation;
        }
        void IDecisionNode.CalculateValue()
        {
            if(this.children.Count == 0)
            {
                throw new EmptyListException("Childrens cannot be empty", "this.children");
            }
            foreach(IConnection child in this.children)
            {
                // Recursily calculate every child
                IDecisionNode currentChild = (child.GetEndPoint() as DecisionNode);
                if (currentChild != null)
                {
                    // currentChild is not decision node
                    currentChild.CalculateValue();
                }    
            }
            this.value = this.calculation.Calculate(this.children);
        }

        void IDecisionNode.AddNode(IConnection connection)
        {
            if(connection == null)
            {
                throw new ArgumentNullException("connection");
            }
            this.children.Add(connection);
        }
        new protected Type GetType()
        {
            if (calculation.GetType() == typeof(EventCalculation))
                return Type.Event;
            else return Type.Decision;
        }
        Type IDecisionNode.GetType()
        {
            return GetType();
        }
    }
}
