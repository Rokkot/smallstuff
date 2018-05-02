using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CommunicationLayer
{
	[DataContract]
	public class StatusInfo
	{
		[DataMember]
		public int InfoID { get; set; }

		[DataMember]
		public string InfoDescription { get; set; }

		[DataMember]
		public object InfoData { get; set; }
	}
}
