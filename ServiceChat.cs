using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using WcfServiceLibraryChat.Interfaces;
using WcfServiceLibraryChat.Model;

namespace WcfServiceLibraryChat
{

	//[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
	//[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	[ServiceBehavior]
	public class ServiceChat : IServiceChat
	{
		List<ServerUser> users = new List<ServerUser>();

		int nextId = 0;

		public int Connect(string name)
		{
			ServerUser user = new ServerUser()
			{
				Id = ++nextId,//Проверить если будет не 0 !!!!!!!!!!!!!!!!!!!!!
				Name = name,
				OperationContext = OperationContext.Current
			};

			//SendMsg(user.Name = "Joined the chat room", 0);

			users.Add(user);

			return user.Id;
		}

		public void Disconnect(int id)
		{
			var user = users.FirstOrDefault(i => i.Id == id);

			if (user != null)
			{
				users.Remove(user);

				user.OperationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(id.ToString());
				//SendMsg(user.Name + "user left the chat room!", 0);
			}
		}

		//public void SendMsg(string msg, int id)
		//{
		//	foreach (ServerUser entity in users)
		//	{
		//		string answer = DateTime.Now.ToShortDateString();

		//		var user = users.FirstOrDefault(i => i.Id == id);

		//		if (user != null)
		//		{
		//			answer += ": " + user.Name + " ";
		//		}

		//		answer += msg;

		//		entity.OperationContext.GetCallbackChannel<IServerChatCallback>().MsgCallBack(answer);

		//	}
		//}
	}
}