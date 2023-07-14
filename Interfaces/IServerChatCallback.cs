using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryChat.Interfaces
{
	public interface IServerChatCallback
	{
		//[OperationContract(IsOneWay = true)]
		void MsgCallback(string msg);
	}
}
