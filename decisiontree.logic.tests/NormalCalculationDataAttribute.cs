using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace DecisionTree.Logic.Tests
{
    public class NormalCalculationDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo testMethod)
        {
            yield return GetItem(GetNormalDecisionTree());
        }

        private object[] GetItem(List<IConnection> tree)
        {
            object[] data = new object[1];
            data[0] = tree;

            return data;
        }
        /// <summary>
        ///         ----3 
        /// decision 
        ///         ----66
        /// </summary>
        /// <returns>Tree</returns>
        private List<IConnection> GetNormalDecisionTree()
        {
            List<IConnection> connections = new List<IConnection>();
            IConnection conn = new Connection();
            ILeaf node = new Node();
            node.SetValue(3);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);
            conn = new Connection();
            node = new Node();
            node.SetValue(66);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);

            return connections;
        }

        private List<IConnection> GetNormalDecisionTreeTwoDepth()
        {
            return null;
        }
    }
}
