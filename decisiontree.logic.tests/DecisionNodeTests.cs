using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Exceptions;
using DecisionTree.Logic.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace DecisionTree.Logic.Tests
{
    public class DecisionNodeTests : DecisionNode
    {

        public DecisionNodeTests()
            : base(Substitute.For<ICalculation>())
        {
        }

        private IDecisionNode _self { get { return this; } }
        /// <summary>
        /// Test calculation without any child
        /// </summary>
        [Fact]
        public void TestCalculationWithNoChildrens()
        {
            Exception ex = Assert.Throws<EmptyListException>(() => _self.CalculateValue());

            Assert.Equal("Childrens cannot be empty", ex.Message);
        }
        /// <summary>
        /// Test if calculation exception on empty childrens throw correct atribute name
        /// </summary>
        [Fact]
        public void TestCalculationWithNoChildrensExceptionParam()
        {
            EmptyListException ex = Assert.Throws<EmptyListException>(() => _self.CalculateValue());

            Assert.Equal("this.children", ex.Atribute);
        }
        /// <summary>
        /// Test if calculation interface received call
        /// </summary>
        [Fact]
        public void TestCalculationInterfaceReceivedCall()
        {
            IConnection conn = Substitute.For<IConnection>();
            conn.AddEndPoint(new Node());
            _self.AddNode(conn);
            _self.CalculateValue();
            calculation.Received(1).Calculate(this.children);
            conn.Received().GetEndPoint();
        }
        /// <summary>
        /// Test adding null connection
        /// </summary>
        [Fact]
        public void TestAddingNullConnection()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _self.AddNode(null));

            Assert.Equal("connection",ex.ParamName);
        }
        /// <summary>
        /// Test adding new connection
        /// </summary>
        [Fact]
        public void TestAddingConnection()
        {
            IConnection conn = new Connection();
            _self.AddNode(conn);

            Assert.Equal(1, this.children.Count);
        }

        [Fact]
        public void TestCreatingNodeWithNullCalculation()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => { new DecisionNode(null); });

            Assert.Equal("calculation", ex.ParamName);
        }


    }
}
