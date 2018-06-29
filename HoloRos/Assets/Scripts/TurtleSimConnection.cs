using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using RosTypes;

public class TurtleSimConnection : MonoBehaviour
{
	public Text text;
	private string t;
	public Integer linear;
	public Integer angular;
	
	private RosConnection ros;

	void Start()
	{
		ros = new RosConnection();
		t = "";
	}
	
	void Update()
	{
		this.text.text = t;
	}

	public void Open()
	{
		ros.OpenConnection();
	}
	
	public void Close()
	{
		ros.CloseConnection();
	}

	public void Send()
	{
		ros.Publish(getJson(), "/turtle1/cmd_vel");
	}

	public void Subscribe()
	{
		ros.Subscribe("/turtle1/pose", MessageReceived, 100);
	}
	
	public void MessageReceived(string data)
	{
		Debug.Log(data);
		this.t = data;
	}

	private RosMsg getJson()
	{
		geometry_msgs_twist t = new geometry_msgs_twist();
		geometry_msgs_vector3 linearVector = new geometry_msgs_vector3();
		geometry_msgs_vector3 angularVector = new geometry_msgs_vector3();
		linearVector.x = linear.integer;
		angularVector.z = angular.integer;
		t.linear = linearVector;
		t.angular = angularVector;
		return t;
	}
	
	private void OnApplicationQuit()
	{
		ros.CloseConnection();
	}
}
