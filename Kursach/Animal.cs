using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	class Animal
	{
		protected int CoordX;
		protected int CoordY;
		protected int Age; // возраст
		protected bool IsDead; //
		List<int[]> Directions = new List<int[]>();
		public Animal(int x, int y)
		{
			CoordX = x;
			CoordY = y;
			Age = 0;
			IsDead = false;
		}
		public int coordX
		{
			get { return CoordX; }
			set { CoordX = value; }
		}
		public int coordY
		{
			get { return CoordY; }
			set { CoordY = value; }
		}
		public int age
		{
			get { return Age; }
			set { Age = value; }
		}
		public bool isDead
		{
			get { return IsDead; }
			set { IsDead = value; }
		}
		public List<int[]> CheckDirections() //определение возможных направлений хода животного
		{
			Directions.Clear();
			int x = coordX;
			int y = coordY;
			int[] coords1 = { x, y }; //создание пары координат
			Directions.Add(coords1); //в случае, если волк остаётся на месте

			if (coordX - 1 >= 0 && coordY - 1 >= 0) //влево вверх
			{
				x = coordX - 1;
				y = coordY - 1;
				int[] coords = { x, y }; //создание пары координат
				Directions.Add(coords);
			}
			if (coordY - 1 >= 0) //вверх
			{
				x = coordX;
				y = coordY - 1;
				int[] coords = { x, y }; //создание пары координат
				Directions.Add(coords);
			}
			if (coordX + 1 < Map.Width && coordY - 1 >= 0) //вправо вверх
			{
				x = coordX + 1;
				y = coordY - 1;
				int[] coords = { x, y }; //создание пары координат
				Directions.Add(coords);
			}
			if (coordX + 1 < Map.Width) //вправо
			{
				x = coordX + 1;
				y = coordY;
				int[] coords = { x, y };
				Directions.Add(coords);
			}
			if (coordX + 1 < Map.Width && coordY + 1 < Map.Height) //вправо вниз
			{
				x = coordX + 1;
				y = coordY + 1;
				int[] coords = { x, y };
				Directions.Add(coords);
			}
			if (coordY + 1 < Map.Height) //вниз
			{
				x = coordX;
				y = coordY + 1;
				int[] coords = { x, y };
				Directions.Add(coords);
			}
			if (coordX - 1 >= 0 && coordY + 1 < Map.Height) //влево вниз
			{
				x = coordX - 1;
				y = coordY + 1;
				int[] coords = { x, y };
				Directions.Add(coords);
			}
			if (coordX - 1 >= 0) //влево
			{
				x = coordX - 1;
				y = coordY;
				int[] coords = { x, y };
				Directions.Add(coords);
			}
			return Directions; //возвращение массива координат
		}
	}
}