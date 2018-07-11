using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTypes
{
    class SubscribeMessage
    {
		public string op;
        public string topic;
        public int throttle_rate;

        public SubscribeMessage(string topic)
        {
            this.op = "subscribe";
            this.topic = topic;

        }

    }
}
