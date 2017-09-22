using DecisionTree.Logic.Calculations;
using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace DecisionTree.Logic.IntegrationTests
{
    public class TreeDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(System.Reflection.MethodInfo testMethod)
        {
            yield return GetItem(TwoDepthTreeWithEventDecision());
            yield return GetItem(TreeDepthTreeWithMixedDecisions());
            yield return GetItem(TreeDepthTreeWithSameBrunches());
        }

        private object[] GetItem(IDecisionNode node)
        {
            object[] data = new object[1];
            data[0] = node;

            return data;
        }

        private IDecisionNode TwoDepthTreeWithEventDecision()
        {
            // Create first leaf
            ILeaf cornGoodMoney = new Node();
            cornGoodMoney.SetValue(8000);

            // Create second leaf
            ILeaf cornBadMoney = new Node();
            cornBadMoney.SetValue(5000);

            // Create connection to first leaf with 0.45 probability
            IEventConnection cornBadConnection = new EventConnection();
            cornBadConnection.SetProbability(0.45);
            cornBadConnection.AddEndPoint(cornBadMoney as INode);

            // Create connection to second leaf with 0.55 probability
            IEventConnection cornGoodConnection = new EventConnection();
            cornGoodConnection.SetProbability(0.55);
            cornGoodConnection.AddEndPoint(cornGoodMoney as INode);

            // Create corn event type node
            IDecisionNode eventCorn = new DecisionNode(new EventCalculation());
            
            // Add event connections to event node
            eventCorn.AddNode(cornGoodConnection);
            eventCorn.AddNode(cornBadConnection);

            // Create third leaf
            ILeaf wheatGoodMoney = new Node();
            wheatGoodMoney.SetValue(7000);

            // Create fourh leaf
            ILeaf wheatBadMoney = new Node();
            wheatBadMoney.SetValue(6500);

            // Create connection for third node with 0.45 probability
            IEventConnection wheatBadConnection = new EventConnection();
            wheatBadConnection.SetProbability(0.45);
            wheatBadConnection.AddEndPoint(wheatBadMoney as INode);

            // Create connection for fourth node with 0.55 probability
            IEventConnection wheatGoodConnection = new EventConnection();
            wheatGoodConnection.SetProbability(0.55);
            wheatGoodConnection.AddEndPoint(wheatGoodMoney as INode);

            // Create wheat event type node
            IDecisionNode eventWheat = new DecisionNode(new EventCalculation());

            // Add event connections to event node
            eventWheat.AddNode(wheatGoodConnection);
            eventWheat.AddNode(wheatBadConnection);

            //Create decision type node
            IDecisionNode decision = new DecisionNode(new DecisionCalculation());
            
            // Create connection for CornNode
            IConnection cornConnection = new Connection();
            cornConnection.AddEndPoint(eventCorn);

            // Create connection for WheatNode
            IConnection wheatConnection = new Connection();
            wheatConnection.AddEndPoint(eventWheat);

            // Add connections to decision node
            decision.AddNode(cornConnection);
            decision.AddNode(wheatConnection);

            return decision;
        }

        private IDecisionNode TreeDepthTreeWithMixedDecisions()
        {
            // Create first leaf
            ILeaf firstLeaf = new Node();
            firstLeaf.SetValue(500);

            IConnection leafConnection = new Connection();
            leafConnection.AddEndPoint(firstLeaf as INode);

            IConnection secondBrunch = new Connection();
            secondBrunch.AddEndPoint(TwoDepthTreeWithEventDecision());

            IDecisionNode decision = new DecisionNode(new DecisionCalculation());

            decision.AddNode(leafConnection);
            decision.AddNode(secondBrunch);

            return decision;

        }
        private IDecisionNode TreeDepthTreeWithSameBrunches()
        {
            
            IConnection secondBrunch = new Connection();
            secondBrunch.AddEndPoint(TwoDepthTreeWithEventDecision());

            IDecisionNode decision = new DecisionNode(new DecisionCalculation());

            decision.AddNode(secondBrunch);
            decision.AddNode(secondBrunch);

            return decision;

        }
        
    }
}
