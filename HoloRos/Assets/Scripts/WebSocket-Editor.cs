#if UNITY_EDITOR
namespace WebsocketEditor
{
	using System;
	using UnityEngine;
	using WebSocketSharp;


	public class WebsocketConnection
	{

		private string url;

		private WebSocket websocketClient;

		public WebsocketConnection(string url)
		{
			websocketClient = new WebSocket(url);
		}

		public delegate void CallbackDelegate(object e, MessageEventArgs args);

		public void SetCallback(CallbackDelegate callbackFunction)
		{
			websocketClient.OnMessage += new EventHandler<WebSocketSharp.MessageEventArgs>(callbackFunction);
		}

		public void Open()
		{
			websocketClient.Connect();
		}
		
		public void Send(string msg)
		{
			websocketClient.Send(msg);
		}

		public void Close()
		{
			websocketClient.Close();
		}
	}
}

#endif