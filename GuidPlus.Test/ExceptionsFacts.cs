using Xunit;

namespace GuidPlus.Test
{
	public class ExceptionsFacts
	{
		[Fact]
		public void NegativeLengthExceptionTest()
		{
			Assert.Throws<Exceptions.NegativeLengthException>(() =>
			{
				new GuidPlus(-1);
			});
		}

		[Fact]
		public void ZeroLengthExceptionTest()
		{
			Assert.Throws<Exceptions.ZeroLengthException>(() =>
			{
				new GuidPlus(0);
			});
		}

		[Fact]
		public void BadStringFormatExceptionTest()
		{
			Assert.Throws<Exceptions.BadStringFormatException>(() =>
			{
				new GuidPlus(string.Empty);
			});
		}
	}
}
