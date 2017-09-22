using DecisionTree.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Logic
{
    public class Connection : IConnection
    {
        protected INode endpoint;
        void IConnection.AddEndPoint(INode node)
        {
            if(node == null)
            {
                throw new ArgumentNullException("node", "Endpoint cannot be null");
            }
            this.endpoint = node;
        }

        INode IConnection.GetEndPoint()
        {
            if(this.endpoint == null)
            {
                throw new NullReferenceException("Endpoint is null");
            }
            return this.endpoint;
        }
    }
}
