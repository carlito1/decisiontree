using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace DecisionTree.Logic.Tests
{
    public class EventCalculationTests : EventCalculation
    {
        ICalculation _self { get { return this; } }
        /// <summary>
        /// Test geting balacend value from weights under normal circumstances
        /// </summary>
        [Fact]
        public void TestNormalCalculation()
        {
            List<IConnection> nodes = new List<IConnection>();
            IEventConnection connection = new EventConnection();
            connection.SetProbability(0.25);
            ILeaf node = new Node();
            node.SetValue(30);

            connection.AddEndPoint(node as INode);

            nodes.Add(connection);
            node = new Node();
            node.SetValue(70);
            connection = new EventConnection();
            connection.SetProbability(0.75);
            connection.AddEndPoint(node as INode);
            nodes.Add(connection);

            Assert.Equal(60, _self.Calculate(nodes));
        }
        /// <summary>
        /// Test geting balacend value from weights if probability is less than one
        /// </summary>
        public void TestProbabilityIsLessThanOne()
        {
            List<IConnection> nodes = new List<IConnection>();
            IEventConnection connection = new EventConnection();
            connection.SetProbability(0.25);
            ILeaf node = new Node();
            node.SetValue(30);

            connection.AddEndPoint(node as INode);

            nodes.Add(connection);
            node = new Node();
            node.SetValue(70);
            connection = new EventConnection();
            connection.SetProbability(0.73);
            connection.AddEndPoint(node as INode);
            nodes.Add(connection);

            ProbabilityException ex = Assert.Throws<ProbabilityException>(() => _self.Calculate(nodes));

            Assert.Equal("Probability is 0.98, but it should be 1.0", ex.Message);
        }
        /// <summary>
        /// Test geting balacend value from weights if probability is more than one
        /// </summary>
        [Fact]
        public void TestProbabilityIsMoreThanOne()
        {
            List<IConnection> nodes = new List<IConnection>();
            IEventConnection connection = new EventConnection();
            connection.SetProbability(0.25);
            ILeaf node = new Node();
            node.SetValue(30);

            connection.AddEndPoint(node as INode);

            nodes.Add(connection);
            node = new Node();
            node.SetValue(70);
            connection = new EventConnection();
            connection.SetProbability(0.77);
            connection.AddEndPoint(node as INode);
            nodes.Add(connection);

            ProbabilityException ex = Assert.Throws<ProbabilityException>(() => _self.Calculate(nodes));

            Assert.Equal("Probability is 1,02, but it should be 1.0", ex.Message);
        }
    }
}
