using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;


namespace DecisionTree.Logic.Tests
{
    
    public class DecisionCalculationTests : DecisionCalculation
    {
        private ICalculation _self { get { return this; } }
        /// <summary>
        /// Test for geting maximum value from children in normal circumstances.
        /// </summary>
        [Theory]
        [NormalCalculationDataAttribute]
        public void TestNormalCalculation(List<IConnection> tree)
        {
            Assert.Equal(66, _self.Calculate(tree));
        }
        /// <summary>
        /// Test for geting maximum value from empty children List
        /// </summary>
        [Fact]
        public void TestEmptyChildrends()
        {
           List<IConnection> connections = new List<IConnection>();
           EmptyListException ex = Assert.Throws<EmptyListException>(() => _self.Calculate(connections));

           Assert.Equal("Nodes cannot be empty", ex.Message);
        }

        /// <summary>
        /// Test geting maximum value with all negative numbers
        /// </summary>
        [Fact]
        public void TestCalculationWithNegativeNumbers()
        {
            List<IConnection> connections = new List<IConnection>();
            IConnection conn = new Connection();
            ILeaf node = new Node();
            node.SetValue(-3);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);
            conn = new Connection();
            node = new Node();
            node.SetValue(-66);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);

            Assert.Equal(-3, _self.Calculate(connections));
        }

        /// <summary>
        /// Test geting maximum value with mixed negative and positive numbers
        /// </summary>
        [Fact]
        public void TestCalculationWithMixedNegativeAndPositiveNumbers()
        {
            List<IConnection> connections = new List<IConnection>();
            IConnection conn = new Connection();
            ILeaf node = new Node();
            node.SetValue(-3);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);
            conn = new Connection();
            node = new Node();
            node.SetValue(-66);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);
            conn = new Connection();
            node = new Node();
            node.SetValue(3);
            conn.AddEndPoint(node as INode);
            connections.Add(conn);

            Assert.Equal(3, _self.Calculate(connections));
        }
    }
}
