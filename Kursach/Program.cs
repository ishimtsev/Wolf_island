using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		
		static void Main()
		{
			//Random r = new Random();
			//Map MAP = new Map();
			//for (int i = 0; i < MAP.RabbitsStartCount; i++)
			//{
			//	//Rabbit t = new Rabbit();
			//	//Map.AnimalsList.Add(t);
			//	MAP.map[r.Next(Map.Width), r.Next(Map.Height)].Add(new Rabbit());
			//}
			//for (int i = 0; i < MAP.WolvesStartCount; i++)
			//{
			//	MAP.map[r.Next(Map.Width), r.Next(Map.Height)].Add(new Wolf());
			//}
			//for (int i = 0; i < MAP.ShewolvesStartCount; i++)
			//{
			//	MAP.map[r.Next(Map.Width), r.Next(Map.Height)].Add(new Shewolf());
			//}
			////Map.map[1,1]=r.Next()


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());

		}
	}
}
