using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
	public interface ICustomEventHandler
	{
		[OperationContract(IsOneWay = true)]
		void CustomEventRaised(string newData);
	}
}
