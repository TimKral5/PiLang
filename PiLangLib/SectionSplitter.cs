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
			char[] chars = _s.ToCharArray();
			chars.Each((char ch) => 
			{
				
			});
		}
	}
}
