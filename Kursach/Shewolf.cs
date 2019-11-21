using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	class Shewolf:Wolf
	{
		int Pregnancy; //волчица беременна на этот ход
		public Shewolf(int x, int y):base(x, y)
		{
			CoordX = x;
			CoordY = y;
			Pregnancy = 0;
			Hunger = 10;
		}
		public int pregnancy
		{
			get { return Pregnancy; }
			set { Pregnancy = value; }
		}
	}
}