using System;
using System.Runtime.Serialization;

namespace GuidPlus.Exceptions
{
	[Serializable]
	public class BadStringFormatException : Exception
	{
		public BadStringFormatException()
		{
		}

		public BadStringFormatException(string message) : base(message)
		{
		}

		public BadStringFormatException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BadStringFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}