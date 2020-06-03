﻿using GuidPlus.Exceptions;
using System;
using System.Linq;
using System.Text;

namespace GuidPlus
{
	/// <summary>
	/// GuidPlus class for advanced GUIDs. It enables developers to use longer GUIDs (in multiples of 128-bit GUID).
	/// </summary>
	public class GuidPlus
	{
		public int Length { get; }

		private readonly Guid[] guids;
		private static readonly char[] expectedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

		/// <summary>
		/// Creates an instance of GuidPlus class.
		/// </summary>
		/// <param name="length">Multiples of 128-bit GUIDs.</param>
		public GuidPlus(int length)
		{
			if (length < 0)
				throw new NegativeLengthException();

			if (length == 0)
				throw new ZeroLengthException();

			while (guids.Length < length)
				guids[guids.Length] = Guid.NewGuid();

			Length = length;
		}

		/// <summary>
		/// Creates an instance of GuidPlus class.
		/// </summary>
		/// <param name="guids">Initial array of GUIDs.</param>

		public GuidPlus(Guid[] guids)
		{
			if (guids.Length == 0)
				throw new ZeroLengthException();

			this.guids = guids;
		}

		/// <summary>
		/// Converts GUIDs to a byte array.
		/// </summary>
		/// <returns></returns>
		public byte[] ToByteArray()
		{
			byte[] result = new byte[guids.Length * 16];

			for (int i = 0; i < guids.Length; i++)
			{
				byte[] guidBytes = guids[i].ToByteArray();
				Array.Copy(guidBytes, 0, result, i * guidBytes.Length, guidBytes.Length);
			}

			return result;
		}

		public override bool Equals(object obj)
		{
			GuidPlus external;

			if (obj == null || !(obj is GuidPlus))
				return false;
			else
				external = (GuidPlus)obj;

			if (external.Length != Length)
				return false;
			else
				return external == this;
		}

		public override int GetHashCode()
		{
			int result = int.MinValue;
			int previousHashCode = guids[guids.Length - 1].GetHashCode();

			for (int i = 0; i < guids.Length; i++)
			{
				int newHashCode = guids[i].GetHashCode();
				result = (result * (result % previousHashCode)) + newHashCode;

				previousHashCode = newHashCode;
			}

			return result;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder(32 * (guids.Length + 5) - 1);

			for (int i = 0; i < guids.Length; i++)
			{
				result.Append(i + 1 < guids.Length ? string.Concat(guids[i].ToString(), "-") : guids[i].ToString());
			}

			return result.ToString();
		}

		public static bool operator ==(GuidPlus a, GuidPlus b)
		{
			if (a.Length != b.Length)
				return false;
			else
				return Enumerable.SequenceEqual(a.guids, b.guids);
		}

		public static bool operator !=(GuidPlus a, GuidPlus b)
		{
			return !(a == b);
		}
	}
}
