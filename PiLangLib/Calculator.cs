using System;
using System.Collections.Generic;
using Kingsoft.Utils.TypeExtensions.Arrays;
using Kingsoft.Utils.BaseSystem;

namespace PiLangLib
{
	public static class Calculator
	{
		public static char[] operations = Converter.operations;

		public static char[] digits = Converter.digits;

		public static float[] Calculate((char[], float[], (int, (int, int))[]) calculation)
		{

			char[] ops = calculation.Item1;
			float[] numbers = calculation.Item2;
			(int, (int, int))[] opNumMap = calculation.Item3;

			Console.Write("numbers: [ ");
			numbers.Each((float num) => Console.Write(num+" "));
			Console.WriteLine("]");

			Console.Write("ops: [ ");
			ops.Each((char op) => Console.Write(op + " "));
			Console.WriteLine("]");

			opNumMap.Each((int index, (int, (int, int)) map) =>
			{
				bool test = false;
				ops.Each((char ch) => { if (ch == '*' || ch == '/') test = true; });
				if (!test) return;

				Console.WriteLine( $"{map.Item1} : {map.Item2.Item1}, {map.Item2.Item2}" );

				char op = ops[map.Item1];
				float numL = numbers[map.Item2.Item1 - index];
				float numR = numbers[map.Item2.Item2 - index];

				void RegisterResult(float _res)
				{
					numbers[map.Item2.Item1 - index] = _res;
					numbers = numbers.Remove(map.Item2.Item2 - index);
				}

				switch (op)
				{
					case '*':
						RegisterResult(numL * numR);
						break;
					case '/':
						RegisterResult(numL / numR);
						break;
					default:
						break;
				}
			});

			opNumMap.Each((int index, (int, (int, int)) map) =>
			{
				bool test = false;
				ops.Each((char ch) => { if (ch == '+' || ch == '-') test = true; });
				if (!test) return;

				Console.WriteLine($"{map.Item1} : {map.Item2.Item1}, {map.Item2.Item2}");

				char op = ops[map.Item1];
				float numL = numbers[map.Item2.Item1 - index];
				float numR = numbers[map.Item2.Item2 - index];

				void RegisterResult(float _res)
				{
					numbers[map.Item2.Item1 - index] = _res;
					numbers = numbers.Remove(map.Item2.Item2 - index);
				}

				switch (op)
				{
					case '+':
						RegisterResult(numL + numR);
						break;
					case '-':
						RegisterResult(numL - numR);
						break;
					default:
						break;
				}
			});

			Console.Write("numbers: [ ");
			numbers.Each((float num) => Console.Write(num + " "));
			Console.WriteLine("]");

			Console.Write("ops: [ ");
			ops.Each((char op) => Console.Write(op + " "));
			Console.WriteLine("]");

			return numbers;
		}
	}
}
