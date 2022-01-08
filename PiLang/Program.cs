using System;
using System.Collections.Generic;
using Kingsoft.Utils.TypeExtensions.Arrays;
using Kingsoft.Utils.TypeExtensions.Dictionaries;
using PiLangLib;
using Spectre.Console;
namespace PiLang
{
	class Program
	{
		static void Main(string[] args)
		{
			FigletFont font1 = FigletFont.Load("font1.flf");
			AnsiConsole.Write(new FigletText(font1, "~~~~~~").Centered());
			AnsiConsole.Write(new FigletText(font1, "Pi-Lang").Centered());
			AnsiConsole.Write(new FigletText(font1, "~~~~~~").Centered());
			AnsiConsole.Write(new Rule("Result").Centered());

			string test = "15 * (4 * (3 + 5))";
			SectionSplitter.Split(test);
			//char[] chars = Converter.Convert(test);
			//float[] res = Calculator.Calculate(Converter.GetOpsAndNums(chars));

			Console.ReadLine();
		}
	}
}
