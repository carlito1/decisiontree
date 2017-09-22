using DecisionTree.Logic.Interfaces;
using System;
using Xunit;

namespace DecisionTree.Logic.Tests
{
    public class EventConnectionTests : EventConnection
    {
        private IEventConnection _self { get { return this; } }

        [Fact]
        public void TestSetingProbability()
        {
            _self.SetProbability(0.1);

            Assert.Equal(0.1,_self.GetProbability());
        }

        [Fact]
        public void TestSetingProbabilityLessThanZero()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => _self.SetProbability(-0.4));

            Assert.Equal("Probability must be between 0 and 1\r\nParameter name: probability",ex.Message);
        }
        [Fact]
        public void TestSettingProbabilityZero()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => _self.SetProbability(0));

            Assert.Equal("Probability must be between 0 and 1\r\nParameter name: probability", ex.Message);
        }
        [Fact]
        public void TestSettingProbabilityMoreThanOne()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => _self.SetProbability(1.1));

            Assert.Equal("Probability must be between 0 and 1\r\nParameter name: probability", ex.Message);
        }
        [Fact]
        public void TestSettingProbabilityOne()
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => _self.SetProbability(1));

            Assert.Equal("Probability must be between 0 and 1\r\nParameter name: probability", ex.Message);
        }
    }
}
