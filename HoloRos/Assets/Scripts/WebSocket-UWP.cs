#if !UNITY_EDITOR
namespace UWPHoloLens
{
	using System;
	using UnityEngine;
	using System.Runtime;

	using Windows.Networking.Sockets;
	using Windows.Storage.Streams;
	using Windows.Networking;
	using Windows.Foundation;
	using Windows.UI.Core;


	public class WebsocketConnection
	{

		private string url;

		private MessageWebSocket messageWebSocket;
		private Uri server;
		private DataWriter dataWriter;
		private DataReader dataReader;
		private CallbackDelegate callback;

		private bool con;

		public WebsocketConnection(string url)
		{
			this.url = url;
			messageWebSocket = new MessageWebSocket();
			con = false;
		}

		public delegate void CallbackDelegate(string s);

		public void SetCallback(CallbackDelegate callbackFunction)
		{
			callback = callbackFunction;
		}

		public void Open()
		{
			messageWebSocket = new MessageWebSocket();
			messageWebSocket.MessageReceived += MessageReceived;
			server = new Uri(url);

			IAsyncAction outstandingAction = messageWebSocket.ConnectAsync(server);
			
			AsyncActionCompletedHandler aach = new AsyncActionCompletedHandler(NetworkConnectedHandler);
			outstandingAction.Completed = aach;
		}

		private void MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
		{
			dataReader = args.GetDataReader();
			string read = dataReader.ReadString(dataReader.UnconsumedBufferLength);
			callback(read);
		}

		public async void Send(string msg)
		{
			if (messageWebSocket != null && con)
			{
				dataWriter.WriteString(msg);
				await dataWriter.StoreAsync();
			}
		}

		public void Close()
		{
			dataWriter.DetachStream();
			dataWriter.Dispose();

			messageWebSocket.Close(1000, "Closed due to user request.");
			con = false;

		}

		public void NetworkConnectedHandler(IAsyncAction asyncInfo, AsyncStatus status)
		{
			if (status == AsyncStatus.Completed)
			{
				con = true;
				dataWriter = new DataWriter(messageWebSocket.OutputStream);
			}
			else
			{
				con = false;
			}
		}
	}
}

#endif