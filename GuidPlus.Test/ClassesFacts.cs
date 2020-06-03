using System;
using System.Linq;
using Xunit;

namespace GuidPlus.Test
{
	public class ClassesFacts
	{
		[Fact]
		public void InstantiateGuidPlus()
		{
			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			GuidPlus testSubject = new GuidPlus(new Guid[] { a, b });

			Assert.NotNull(testSubject);
		}

		[Fact]
		public void ValidateToByteArray()
		{
			byte[] expected = new byte[32];

			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			Array.Copy(a.ToByteArray(), 0, expected, 0, 16);
			Array.Copy(b.ToByteArray(), 0, expected, 16, 16);

			GuidPlus testSubject = new GuidPlus(new Guid[] { a, b });

			Assert.True(Enumerable.SequenceEqual(expected, testSubject.ToByteArray()));
		}

		[Fact]
		public void ValidateToString()
		{
			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			GuidPlus testSubject = new GuidPlus(new Guid[] { a, b });

			Assert.Equal(string.Concat(a.ToString(), "-", b.ToString()), testSubject.ToString());
		}

		[Fact]
		public void ValidateGetHashCode()
		{
			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			GuidPlus testSubjectOne = new GuidPlus(new Guid[] { a, b });
			GuidPlus testSubjectTwo = new GuidPlus(new Guid[] { b, a });

			Assert.NotEqual(testSubjectOne.GetHashCode(), testSubjectTwo.GetHashCode());
		}

		[Fact]
		public void ValidateEquals()
		{
			Guid a = Guid.NewGuid();
			Guid b = Guid.NewGuid();

			GuidPlus testSubjectOne = new GuidPlus(new Guid[] { a, b });
			GuidPlus testSubjectTwo = new GuidPlus(new Guid[] { a, b });

			Assert.True(testSubjectOne.Equals(testSubjectTwo));
		}
	}
}
