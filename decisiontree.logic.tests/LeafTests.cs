using DecisionTree.Logic.Interfaces;
using System;
using Xunit;

namespace DecisionTree.Logic.Tests
{
    public class LeafTests : Node
    {
        [Fact]
        public void TestLeafSetMethod()
        {
            INode _selfNode = this;
            ILeaf _selfLeaf = this;

            _selfLeaf.SetValue(5);

            Assert.Equal(5, _selfNode.GetValue());
        }
    }
}
