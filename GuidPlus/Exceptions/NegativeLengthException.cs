using System;
using System.Runtime.Serialization;

namespace GuidPlus.Exceptions
{
	[Serializable]
	public class NegativeLengthException : Exception
	{
		public NegativeLengthException()
		{
		}

		public NegativeLengthException(string message) : base(message)
		{
		}

		public NegativeLengthException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NegativeLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}