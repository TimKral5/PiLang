using System;
using Kingsoft.Utils.TypeExtensions.String;
using Kingsoft.Utils.TypeExtensions.Arrays;

namespace PiLangLib
{
	public static class SectionSplitter
	{
		public static char[] operations = Converter.operations;

		public static char[] digits = Converter.digits;

		public static void Split(string _s)
		{
			char[] newChars = new char[0];

			char[] include = new char[] { '(', ')' };
			char[] chars = _s.ToCharArray();
			chars.Each((int i, char ch) =>
			{
				digits.Each((char _ch) => { if (ch == _ch) newChars = newChars.Append(ch); });
				digits.Each((char _ch) => { if (ch == _ch) newChars = newChars.Append(ch); });
				include.Each((char _ch) => { if (ch == _ch) newChars = newChars.Append(ch); });
			});

			char[][][] layers = new char[][][] { new char[][] { new char[0] } };

			int layerNum = 0;
			newChars.Each((char ch) =>
			{
				switch (ch)
				{
					case '(':
						layers = layers.Append(new char[0][].Append(new char[0]));
						layerNum++;
						return;
					case ')':
						layers[layerNum][layers[layerNum].Length - 1] =
							layers[layerNum][layers[layerNum].Length - 1].Append('V');
						layerNum--;
						return;
					default:
						layers[layerNum][layers[layerNum].Length - 1] =
							layers[layerNum][layers[layerNum].Length - 1].Append(ch);
						return;
				}
			});

			float[][] xVals = new float[0][];
			layers.Each((int i, char[][] layer) =>
			{
				xVals.Append(new float[0]);
				layer.Each((int _i, char[] _chars) =>
				{
					int x = -1;
					_chars.Each((int _j, char ch) => { if (ch == 'V') x = _j; });

					if (x != -1)
					{
						char[] num = xVals[i][0].ToString().ToCharArray();
						_chars = _chars.Inject(x, num).Remove(x);
					}

					xVals[i].Append(Calculator.Calculate(Converter.GetOpsAndNums(_chars)));
				});

			}, true);
		}
	}
}
