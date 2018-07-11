using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RosTypes;

public class Ur5Connection : MonoBehaviour {

	private RosConnection ros;

	private GameObject[] jointList = new GameObject[6];
	private Vector3[] rotations = new Vector3[6];
	public GameObject RobotBase;

	// Use this for initialization
	void Start() {
		initializeJoints();

		ros = new RosConnection();
		ros.OpenConnection();
		ros.Subscribe("/move_ur/getAllJoints", MessageReceived);
	}

	void Update()
	{
		for (int i = 0; i < 6; i++)
		{
			jointList[i].transform.localEulerAngles = rotations[i];
		}
	}

	public void MessageReceived(string data)
	{
		JObject q = JObject.Parse(data);

		foreach (JProperty s in q.Properties())
		{
			if (s.Value.Type == JTokenType.Object)
			{
				JObject n = JObject.Parse(s.Value.ToString());
				foreach (JProperty c in n.Properties())
				{
					float rad = 0.0f;
					try
					{
						float.TryParse(c.Value.ToString(), out rad);
					}
					catch (Exception ex)
					{
						Debug.Log(ex.Message);
					}

					int degrees = RadToDeg(rad);

					switch (c.Name.ToString())
					{
						case "joint1":
							{
								rotations[0].z = 0-(degrees + 45);
								break;
							}
						case "joint2":
							{
								rotations[1].z = degrees + 90;
								break;
							}
						case "joint3":
							{
								rotations[2].z = degrees;
								break;
							}
						case "joint4":
							{
								rotations[3].z = degrees + 90;
								break;
							}
						case "joint5":
							{
								rotations[4].z = 0-(degrees);
								break;
							}
						case "joint6":
							{
								rotations[5].z = degrees;	
								break;
							}
						default:
							{
								Debug.Log("Not a joint!");
								break;
							}
					}
				}
			}
		}
	}

	// Create the list of GameObjects that represent each joint of the robot
	void initializeJoints()
	{

		var RobotChildren = RobotBase.GetComponentsInChildren<Transform>();
		for (int i = 0; i < RobotChildren.Length; i++)
		{
			if (RobotChildren[i].name == "control0")
			{
				jointList[0] = RobotChildren[i].gameObject;
			}
			else if (RobotChildren[i].name == "control1")
			{
				jointList[1] = RobotChildren[i].gameObject;
			}
			else if (RobotChildren[i].name == "control2")
			{
				jointList[2] = RobotChildren[i].gameObject;
			}
			else if (RobotChildren[i].name == "control3")
			{
				jointList[3] = RobotChildren[i].gameObject;
			}
			else if (RobotChildren[i].name == "control4")
			{
				jointList[4] = RobotChildren[i].gameObject;
			}
			else if (RobotChildren[i].name == "control5")
			{
				jointList[5] = RobotChildren[i].gameObject;
			}
		}

		for (int i = 0; i < 6; i++)
		{
			rotations[i] = jointList[i].transform.localEulerAngles;

		}
	}

	private int RadToDeg(float rad)
	{
		double deg = (rad * (180 / Math.PI));
		return Convert.ToInt32(deg);
	}

	private void OnApplicationQuit()
	{
		ros.CloseConnection();
	}
}
