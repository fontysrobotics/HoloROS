using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosTypes
{
	public class simpleEndEffector : RosMsg
	{

		public float posx = 0;
		public float posy = 0;
		public float posz = 0;
		public float roll = 0;
		public float pitch = 0;
		public float yaw = 0;
		public bool planOnly = false;
		public bool confirmation = true;

	}
}