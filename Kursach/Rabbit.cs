using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	class Rabbit:Animal
	{
		public Rabbit(int x, int y):base(x, y)
		{
			CoordX = x;
			CoordY = y;
		}
	}
}