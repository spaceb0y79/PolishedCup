
using System.Runtime.Serialization;

namespace PolishedCup.Models
{
    [DataContract]
	public class DataResponse<T> : ActionResponse
	{
		[DataMember]
		public T Data { get; set; }
	}
}

