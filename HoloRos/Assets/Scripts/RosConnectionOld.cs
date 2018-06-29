using System.Collections;
using System.Collections.Generic;
using System.Threading;
//using System.Net.WebSockets;
using System;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
//using WebSocket4Net;
using RosTypes;

#if UNITY_EDITOR
using WebSocketSharp;
#endif

#if !UNITY_EDITOR
//using Websockets;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.Networking;
using Windows.Foundation;
using Windows.UI.Core;	
#endif


public class RosConnectionOld : MonoBehaviour
{
	//public int linear;
	//public int angular;
	//public InputField lin;
	//public InputField ang;
	private const string url = "ws://145.93.170.42:9090";
	public Text text;
	string t;

	public Integer linear;
	public Integer angular;
	
	 public bool con;

	//ClientWebSocket w;
	//Uri uri;
	//ArraySegment<byte> arr;

#if UNITY_EDITOR
	private WebSocket websocketClient;
#endif
#if !UNITY_EDITOR
	//private IWebSocketConnection connection;
	    private MessageWebSocket messageWebSocket;
    Uri server;
    DataWriter dataWriter;
#endif

	void Awake()
	{
		//w = new ClientWebSocket();
		//uri = new Uri("ws://145.93.174.31:9090");
		//setArray();

		//websocketClient = new WebSocket("ws://192.168.42.132:9090");
#if UNITY_EDITOR
		websocketClient = new WebSocket(url);
		websocketClient.Connect();
		websocketClient.Send(getJson());
#endif
text.text = "Got here!";
#if !UNITY_EDITOR
		con = false;
		
#endif
		//websocketClient.OnMessage += new EventHandler<WebSocketSharp.MessageEventArgs>(websocketClient_OnMessage);

		//websocketClient.OnMessage += new EventHandler<MessageReceivedEventArgs>(websocketClient_MessageReceived);

	}

	void Update()
	{
		//text.text = t;
		//text.text = "Got here!";
		#if UNITY_EDITOR
		text.text = "Editro! here!";
#endif

#if !UNITY_EDITOR
		//text.text = "UWP here!";
#endif
	}

	public void Open()
	{
		//websocketClient.Connect();
#if !UNITY_EDITOR
		//Websockets.Universal.WebsocketConnection.Link();
		//connection = Websockets.WebSocketFactory.Create();
		//connection.OnMessage += Connection_OnMessage;
		//connection.Open(url);
		
		messageWebSocket = new MessageWebSocket();

        server = new Uri(url);

        IAsyncAction outstandingAction = messageWebSocket.ConnectAsync(server);
        AsyncActionCompletedHandler aach = new AsyncActionCompletedHandler(NetworkConnectedHandler);
        outstandingAction.Completed = aach;
#endif
	}
	
	
//Successfull network connection handler on HL
#if !UNITY_EDITOR
    public void NetworkConnectedHandler(IAsyncAction asyncInfo, AsyncStatus status)
    {
        // Status completed is successful.
        if (status == AsyncStatus.Completed)
        {
            //Guarenteed connection
            con = true;
            
            //Creating the writer that will be repsonsible to send a message through Rosbridge
            dataWriter = new DataWriter(messageWebSocket.OutputStream);

        }
        else
        {
            con = false;
        }
    }
#endif


	public void Send()
	{

		//websocketClient.Send(getJson());
#if !UNITY_EDITOR
		//connection.Send(getJson());
		if (messageWebSocket != null)
        {
            //string s = CallService(service, args);
            dataWriter.WriteString(getJson());
            dataWriter.StoreAsync();
        }
#endif

	}

	public void Subscribe()
	{
		SubscribeMessage s = new SubscribeMessage("subscribe", "/turtle1/pose");
		s.throttle_rate = 0;
		s.queue_length = 1;
		string json = JsonConvert.SerializeObject(s);

		//websocketClient.Send(json);
	}

	public void Stop()
	{
		//websocketClient.Close();
#if !UNITY_EDITOR
		//connection.Close();
		 messageWebSocket.Dispose();
        messageWebSocket = null;
        con = false;
#endif
	}
	private void Connection_OnMessage(string msg)
	{

	}

	//private void websocketClient_OnMessage(object sender, WebSocketSharp.MessageEventArgs e)
	//{
	//	t = e.Data;
	//}

	//private void websocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
	//{
	//	t = e.Message;
	//}

	private string getJson()
	{
		geometry_msgs_twist t = new geometry_msgs_twist();
		geometry_msgs_vector3 linearVector = new geometry_msgs_vector3();
		geometry_msgs_vector3 angularVector = new geometry_msgs_vector3();
		//linearVector.x = linear.integer;
		//angularVector.z = angular.integer;
		linearVector.x = 1;
		angularVector.z = 0;
		t.linear = linearVector;
		t.angular = angularVector;
		PublishMessage p = new PublishMessage("publish", "/turtle1/cmd_vel", t);
		string json = JsonConvert.SerializeObject(p);
		//string json = "";
		this.t = json;
		return json;
		//return "";
	}
}
