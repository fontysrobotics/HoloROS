using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTypes
{
    class PublishMessage
    {
        public string op;
        public string topic;
        public RosMsg msg;

		public PublishMessage(string topic, RosMsg msg)
		{
			this.op = "publish";
			this.topic = topic;
			this.msg = msg;
		}
    }
}
