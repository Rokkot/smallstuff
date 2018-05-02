using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CommunicationLayer
{
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICustomEventHandler))]
	public interface ICommunicationServiceControl
	{
		[OperationContract]
		bool ExecuteCommand(CommandData _data);

		[OperationContract]
		List<StatusInfo> GetStatusInfo();

		[OperationContract(IsOneWay = false/*, IsInitiating = true*/)]
		void SubscribeForEvernts();

		[OperationContract(IsOneWay = false/*, IsTerminating = true*/)]
		void UnSubscribeFromEvernts();

		[OperationContract]
		bool IsRunning();
	}
}
