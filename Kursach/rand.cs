using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	static class random
	{
		static Random rand = new Random();
		public static int Next()
		{
			return rand.Next();
		}
		public static int Next(int x)
		{
			return rand.Next(x);
		}
		public static int Next(int x, int y)
		{
			return rand.Next(x, y);
		}
	}
}
