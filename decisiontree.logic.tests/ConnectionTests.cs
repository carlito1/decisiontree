using DecisionTree.Logic.Interfaces;
using System;
using Xunit;

namespace DecisionTree.Logic.Tests
{
    public class ConnectionTest : Connection
    {
        private IConnection _self { get { return this; } }
        [Fact]
        public void TestSetingEndPoint()
        {
            Node node = new Node();
            _self.AddEndPoint(node);
            Assert.NotNull(_self.GetEndPoint());
        }
        [Fact]
        public void TestGetingEndPoint()
        {
            ILeaf node = new Node();
            node.SetValue(10);

            _self.AddEndPoint(node as INode);

            Assert.Equal(10, _self.GetEndPoint().GetValue());
        }
        [Fact]
        public void TestSettingNullEndpointExceptionMessage()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _self.AddEndPoint(null));

            Assert.Equal("Endpoint cannot be null\r\nParameter name: node", ex.Message);
        }
        [Fact]
        public void TestSettingNullEndpointExceptionParamName()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _self.AddEndPoint(null));

            Assert.Equal("node", ex.ParamName);
        }
        [Fact]
        public void TestGettingNullEndpointException()
        {
            this.endpoint = null;

            Exception ex = Assert.Throws<NullReferenceException>(() => _self.GetEndPoint());

            Assert.Equal("Endpoint is null", ex.Message);
        }
    }
}
