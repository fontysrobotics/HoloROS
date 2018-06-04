using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTypes
{
    class SubscribeMessage : ROSMessage
    {
        public string topic;
        //public string id;
        //public string type;
        public int throttle_rate;
        public int queue_length;
        //public int fragment_size;
        //public string compression;

        public SubscribeMessage(string op, string topic)
        {
            this.op = op;
            this.topic = topic;

        }

    }
}


/*{ "op": "subscribe",
  (optional) "id": <string>,
  "topic": <string>,
  (optional) "type": <string>,
  (optional) "throttle_rate": <int>,
  (optional) "queue_length": <int>,
  (optional) "fragment_size": <int>,
  (optional) "compression": <string>
}
*/