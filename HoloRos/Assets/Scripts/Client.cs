using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Websockets;

public class Client : MonoBehaviour {
	
	
	private Websockets.IWebSocketConnection connection;

	public string uri;

	

	void Start () {
	//#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
	 //Websockets.Net.WebsocketConnection.Link();
	 //#else
	 //Websockets.Universal.WebsocketConnection.Link();
		
		connection = Websockets.WebSocketFactory.Create();
		connection.OnError += Connection_OnError;
		connection.OnMessage += Connection_OnMessage;
		connection.OnOpened += Connection_OnOpened;
	}

	public void Open()
	{
		if (uri != "" && uri != null)
		{
			connection.Open(uri);
		}
	}

	public void SendMessage(string message)
	{
		connection.Send(message);
	}

	public void Stop()
	{
		connection.Close();

		//WriteLine();
		//Console.WriteLine("Client disconnected!");
	}

	private void Connection_OnOpened()
	{
		//Console.WriteLine();
		//Console.WriteLine("Client successfully connected.");
		//Console.WriteLine();
	}

	private void Connection_OnMessage(string obj)
	{
		//Console.WriteLine();
		//Console.WriteLine("Message Received. Server answered: " + obj);
	}

	private void Connection_OnError(string obj)
	{
		//Console.WriteLine(obj);
	}
}
