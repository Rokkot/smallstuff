using System.Collections.Generic;
using System.ServiceModel;

namespace CommunicationLayer
{
	[ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICustomEventHandler))]
	public interface ICommunicationService
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
