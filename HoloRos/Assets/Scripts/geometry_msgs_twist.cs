using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosTypes
{
    class geometry_msgs_twist : RosMsg
    {
        public geometry_msgs_vector3 linear;
        public geometry_msgs_vector3 angular;
    }
}
