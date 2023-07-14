using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryChat.Interfaces
{
	[ServiceContract(CallbackContract = typeof(IServerChatCallback))]
	public interface IServiceChat
	{
		[OperationContract]
		int Connect(string name);

		[OperationContract]
		void Disconnect(int id);
	}
}
