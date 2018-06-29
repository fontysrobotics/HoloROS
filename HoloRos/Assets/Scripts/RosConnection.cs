using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RosTypes;

#if UNITY_EDITOR
using UWPEditor;
#endif

#if !UNITY_EDITOR
using UWPHoloLens;
#endif

public class RosConnection
{
	private const string url = "ws://145.93.173.18:9090";
	private WebsocketConnection connection;

	private Dictionary<string, CallbackDelegate> callbacks;

	public delegate void CallbackDelegate(string data);

	public RosConnection()
	{
		callbacks = new Dictionary<string, CallbackDelegate>();
		connection = new WebsocketConnection(url);
	}
	
	public void OpenConnection()
	{
		connection.Open();
		connection.SetCallback(MessageReceived);
	}
	
	public void CloseConnection()
	{
		connection.Close();
	}
	
	public void Subscribe(string topic, CallbackDelegate cb, int throttle = 0)
	{
		callbacks.Add(topic, cb);

		SubscribeMessage s = new SubscribeMessage("subscribe", topic);
		s.throttle_rate = throttle;
		string json = JsonConvert.SerializeObject(s);

		connection.Send(json);
	}

	public void Publish(RosMsg msg, string topic)
	{
		PublishMessage p = new PublishMessage("publish", topic, msg);
		string json = JsonConvert.SerializeObject(p);
		connection.Send(json);
	}

	public void MessageReceived(object e, WebSocketSharp.MessageEventArgs args)
	{
		string topic = "";
		JObject jsonObject = JObject.Parse(args.Data);

		foreach (JProperty property in jsonObject.Properties())
		{
			if(property.Name == "topic")
			{
				topic = property.Value.ToString();
				continue;
			}
		}
		
		try
		{
			callbacks[topic](args.Data);
		}
		catch(KeyNotFoundException)
		{
			Debug.Log("Could not find the topic registered!");
		}
	}

	public void MessageReceived(string data)
	{
		string topic = "";
		JObject jsonObject = JObject.Parse(data);

		foreach (JProperty property in jsonObject.Properties())
		{
			if (property.Name == "topic")
			{
				topic = property.Value.ToString();
				continue;
			}
		}

		try
		{
			callbacks[topic](data);
		}
		catch (KeyNotFoundException)
		{
			Debug.Log("Could not find the topic registered!");
		}
	}

}
