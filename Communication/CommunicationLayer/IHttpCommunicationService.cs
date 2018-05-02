using System.Collections.Generic;
using System.ServiceModel;

namespace CommunicationLayer
{
	public interface IHttpCommunicationService
	{
		[OperationContract]
		bool ExecuteCommand(CommandData _data);

		[OperationContract]
		List<StatusInfo> GetStatusInfo();

		[OperationContract]
		bool IsRunning();
	}
}
