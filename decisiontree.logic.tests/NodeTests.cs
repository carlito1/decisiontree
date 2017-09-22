using DecisionTree.Logic.Interfaces;
using System;
using Xunit;


namespace DecisionTree.Logic.Tests
{
    public class NodeTests : Node
    {
        private INode _self {get {return this;}}
        [Fact]
        public void TestGetValue()
        {
            this.value = 10;
            Assert.Equal(10, _self.GetValue());
        }
        [Fact]
        public void TestChildrenIsNotNull()
        {
            Assert.NotNull(this.children);
        }
        [Fact]
        public void TestSetingName()
        {
            _self.SetName("Ziga");
            Assert.Equal("Ziga", _self.GetName());
        }
        [Fact]
        public void TestSetingNullName()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _self.SetName(null));

            Assert.NotNull(ex);
        }
    }
}
