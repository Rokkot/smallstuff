using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommunicationLayer
{
	[DataContract]
	public class CommandData
	{
		[DataMember]
		public int CommandID { get; set; }

		[DataMember]
		public List<object> CommandParams { get; set; }
	}
}
