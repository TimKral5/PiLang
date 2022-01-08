using System;
using System.Collections.Generic;
using Kingsoft.Utils.TypeExtensions.String;
using Kingsoft.Utils.TypeExtensions.Arrays;
using Kingsoft.Utils.TypeExtensions.Dictionaries;

namespace PiLangLib
{
	public static class Converter
	{

		public static char[] operations = new char[]
		{
			'+', '-',
			'*', '/'
		};

		public static char[] digits = new char[]
		{
			'.',
			'0', '1',
			'2', '3',
			'4', '5',
			'6', '7',
			'8', '9'
		};

		public static char[] Convert(string _s)
		{
			char[] chars = _s.ToCharArray();

			char[] _chars = new char[]
			{
				'+', '-',
				'*', '/',
				'0', '1',
				'2', '3',
				'4', '5',
				'6', '7',
				'8', '9'
			};

			char[] res = new char[0];

			chars.Each((char ch) => {
				_chars.Each((char _ch) 
					=> { if (ch == _ch) res = res.Append(ch); });
			});
			return res;
		}

		public static (char[], float[], (int, (int, int))[]) GetOpsAndNums(char[] calculation)
		{
			bool recordNum = true;
			string currentNum = "";

			float[] numbers = new float[0];
			char[] ops = new char[0];

			(int, (int, int))[] opNumMap = new (int, (int, int))[0];

			calculation.Each((int index, char ch) =>
			{
				operations.Each((char o) =>
				{
					if (ch == o) ops = ops.Append(o);
					if (ch == o && recordNum) recordNum = false;
				});

				digits.Each((char f) => { if (ch == f && recordNum) currentNum += f; });

				if (!recordNum || index == calculation.Length - 1)
				{
					numbers = numbers.Append(float.Parse(currentNum));
					Console.WriteLine(currentNum);
					currentNum = "";
					if (!recordNum) opNumMap = opNumMap.Append(
						(ops.Length - 1, (numbers.Length - 1, numbers.Length)));
					recordNum = true;
				}
			});

			return (ops, numbers, opNumMap);
		}
	}
}
