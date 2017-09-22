using DecisionTree.Logic.Interfaces;
using System;
using Xunit;

namespace DecisionTree.Logic.IntegrationTests
{
    public class TreeTests
    {
        [Trait("Intergration tests", "Tree tests")]
        [Theory]
        [TreeDataAttribute]
        public void TestTree(IDecisionNode tree)
        {
            tree.CalculateValue();
            Assert.Equal(6775, tree.GetValue());
        }
    }
}
