using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
//using Newtonsoft.Json;
using RosTypes;


public class ROSConnection : MonoBehaviour {
	//public int linear;
	//public int angular;
	//public InputField lin;
	//public InputField ang;
	
	public Text text;
	string t;
	
	public Integer linear;
	public Integer angular;
	public Client websocket;
	
	//ClientWebSocket w;
	//Uri uri;
	//ArraySegment<byte> arr;
	
	// WebSocket websocketClient;
	//public InputField XAxis;
	//public InputField Angle;
	 //TouchScreenKeyboard keyboard;
    //public static string keyboardText = "";
	
	
	
	void Awake()
	{
		
		//w = new ClientWebSocket();
		//uri = new Uri("ws://145.93.174.31:9090");
		//setArray();
		
		//websocketClient = new WebSocket("ws://192.168.42.132:9090");
		//websocketClient = new WebSocket("ws://145.93.174.246:9090");

        //websocketClient.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocketClient_MessageReceived);
		websocket.uri = "ws://145.93.168.243:9090";
		
		
	}
	
	void Update()
	{
		text.text = t;
	}
	
	public void Open()
	{
		websocket.Open();
	}

	public void Send()
	{

		websocket.SendMessage(getJson());

	}
	
	public void Subscribe()
	{
		SubscribeMessage s = new SubscribeMessage("subscribe", "/turtle1/pose");
		s.throttle_rate = 0;
		s.queue_length = 1;
		//string json = JsonConvert.SerializeObject(s);
string json = "";
		websocket.SendMessage(json);
	}

	public void Stop()
	{
		websocket.Stop();
	}

	//private void websocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
	//{
	//	t = e.Message;
	//}

	private string getJson()
	{
		geometry_msgs_twist t = new geometry_msgs_twist();
		geometry_msgs_vector3 linearVector = new geometry_msgs_vector3();
		geometry_msgs_vector3 angularVector = new geometry_msgs_vector3();
		linearVector.x = linear.integer;
		angularVector.z = angular.integer;
		t.linear = linearVector;
		t.angular = angularVector;
		PublishMessage p = new PublishMessage("publish", "/turtle1/cmd_vel", t);
		//string json = JsonConvert.SerializeObject(p);
		string json = "";
		this.t = json;
		return json;
	}
}
