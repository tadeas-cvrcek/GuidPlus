using System;
using System.Runtime.Serialization;

namespace GuidPlus.Exceptions
{
	[Serializable]
	public class ZeroLengthException : Exception
	{
		public ZeroLengthException()
		{
		}

		public ZeroLengthException(string message) : base(message)
		{
		}

		public ZeroLengthException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ZeroLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}