using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	class Wolf:Animal
	{
		protected int Hunger; //сытость
		public Wolf(int x, int y):base(x, y)
		{
			CoordX = x;
			CoordY = y;
			Hunger = 10;
		}
		public int hunger
		{
			get { return Hunger; }
			set { Hunger = value; }
		}
	}
}