using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
	class Map
	{
		const int height = 20; //ширина поля
		const int width = 20; //высота поля

		int rabbitsStartCount = 20;
		int wolvesStartCount = 7;
		int shewolvesStartCount = 7;

		int rabbitIsAdult = 1;
		int wolfIsAdult = 2;

		int rabbitsDeath = 7;
		int wolvesDeath = 20;
		List<Animal> AnimalsList = new List<Animal>(); //список всех животных
		List<Animal> TempAnimalsList = new List<Animal>(); //дополнительный список животных
		public void Turn() //основная функция хода всех животных
		{
			//
			//ходы кроликов
			//
			foreach (Animal animal in animalsList) //цикл по общему списку животных
			{
				if (animal.GetType() == typeof(Rabbit)) //если данное животное - это кролик
				{
					Rabbit rabbit = animal as Rabbit; //приведение объекта к типу "Кролик" для дальнейшей работы с ним
					rabbit.age++; //взросление кролика

					List<int[]> Directions = rabbit.CheckDirections(); //определение возможных направлений хода
					int rand = random.Next(Directions.Count); //выбор случайной пары координат
					rabbit.coordX = Directions[rand][0]; //перемещение кролика
					rabbit.coordY = Directions[rand][1]; //

					if (random.Next(5) == 1 && rabbit.age > RabbitIsAdult) //если кролик взрослый, то с вероятностью 0,2 создаётся новый кролик
						tempAnimalsList.Add(new Rabbit(rabbit.coordX, rabbit.coordY));

					if (rabbit.age == RabbitsDeath) //если кролик старый
						rabbit.isDead = true; //смерть кролика
				}
			}

			CleanList(); //исключение мёртвых животных из списка
			TransferToMainList(); //перенос крольчат из временного списка в основной
			//
			//ходы волков и волчиц
			//
			foreach (Animal animal in animalsList) //цикл по общему списку животных
			{
				if (animal.GetType() == typeof(Wolf) || animal.GetType() == typeof(Shewolf)) //если данное животное - это волк или волчица
				{
					Wolf wolf = animal as Wolf; //приведение объекта к типу "Волк" для дальнейшей работы с ним
					wolf.age++; //взросление волка
					bool initiative = true; //инициатива

					List<int[]> Directions = wolf.CheckDirections(); //вычисление возможных направлений движения

					if (animal.GetType() == typeof(Shewolf)) //если данное животное - это волчица
					{
						Shewolf shewolf = animal as Shewolf;
						if (shewolf.pregnancy == 1) //если беременность подходит к концу
						{
							if (random.Next(2) == 0) //выбор пола волчонка
								tempAnimalsList.Add(new Wolf(shewolf.coordX, shewolf.coordY)); //рождение
							else
								tempAnimalsList.Add(new Shewolf(shewolf.coordX, shewolf.coordY)); //рождение
						}
						if (shewolf.pregnancy > 0) 
							shewolf.pregnancy--; //увеличение срока
					}

					if (wolf.hunger <= 6 && wolf.age >= WolfIsAdult) //если волк взрослый и голоден, начинается поиск кроликов
					{
						for (int i = 0; i < Directions.Count; i++) //кролики ищутся в клетках, доступных для перемещения
						{
							foreach (Animal an in animalsList)
							{
								if (an.GetType() == typeof(Rabbit))
								{
									Rabbit rabbit = an as Rabbit;

									if (rabbit.coordX == Directions[i][0] && rabbit.coordY == Directions[i][1]
										&& !rabbit.isDead) //если кролик в нужной клетке и ещё не съеден
									{
										wolf.coordX = Directions[i][0]; // перемещение волка к кролику
										wolf.coordY = Directions[i][1]; //
										rabbit.isDead = true; //волк кушает кролика
										wolf.hunger += 10; //повышение сытости
										initiative = false; //инициатива отключается
									}
									if (!initiative)
										break;
								}
							}
							if (!initiative)
								break;
						}
					}
					if (initiative && wolf.age >= WolfIsAdult) //поиск партнёра для размножения
					{
						if (animal.GetType() == typeof(Wolf)) //если животное - волк, то ищется волчица
						{
							foreach (Animal an in animalsList)
							{
								if (an.GetType() == typeof(Shewolf))
								{
									Shewolf s = an as Shewolf;
									for (int i = 0; i < Directions.Count; i++) //поиск в клетках, доступных для перемещения
									{
										if (s.coordX == Directions[i][0] && s.coordY == Directions[i][1]
											&& s.age >= 2 && s.pregnancy == 0 && !s.isDead) //если координаты и остальные условия совпадают
										{
											wolf.coordX = Directions[i][0]; // перемещение к волчице
											wolf.coordY = Directions[i][1]; //
											s.pregnancy = 3; //волчица забеременела
											initiative = false; //инициатива отключается
										}
										if (!initiative)
											break;
									}
									if (!initiative)
										break;
								}
							}
						}
						else //если животное - волчица, то ищется волк
						{
							Shewolf shewolf = animal as Shewolf;
							if (shewolf.pregnancy == 0) //если волчица сейчас не беременна
							{
								foreach (Animal an in animalsList)
								{
									if (an.GetType() == typeof(Wolf))
									{
										Wolf w = an as Wolf;
										for (int i = 0; i < Directions.Count; i++) //поиск в клетках, доступных для перемещения
										{
											if (w.coordX == Directions[i][0] && w.coordY == Directions[i][1]
												&& w.age >= 2 && !w.isDead) //если координаты и остальные условия совпадают
											{
												wolf.coordX = Directions[i][0]; // перемещение к волку
												wolf.coordY = Directions[i][1]; //
												shewolf.pregnancy = 3; //волчица забеременела
												initiative = false; //инициатива отключается
											}
											if (!initiative)
												break;
										}
										if (!initiative)
											break;
									}
								}
							}
						}
					}
					wolf.hunger -= 1; //уменьшение сытости за ход
					if (wolf.hunger == 0 || wolf.age == WolvesDeath) //смерть волка от голода или от старости
					{
						wolf.isDead = true;
						continue;
					}
					if (initiative) //просто ход в случайном направлении (при отсутствии других вариантов)
					{
						int rand = random.Next(Directions.Count);
						wolf.coordX = Directions[rand][0];
						wolf.coordY = Directions[rand][1];
					}
				}
			}
			CleanList(); //исключение мёртвых животных из списка
			TransferToMainList(); //перенос волчат из временного списка в основной

		}
		void CleanList() //исключение мёртвых животных из списка 
		{
			for (int i = 0; i < animalsList.Count; i++)
			{
				if (animalsList[i].isDead)
				{
					animalsList.RemoveAt(i);
					i--;
				}
			}
		}
		void TransferToMainList() //перенос животных из временного списка в основной
		{
			foreach (Animal animal in tempAnimalsList)
			{
				animalsList.Add(animal);
			}
			tempAnimalsList.Clear();
		}
		public List<Animal> animalsList
		{
			get { return AnimalsList; }
			set { AnimalsList = value; }
		}
		public List<Animal> tempAnimalsList
		{
			get { return TempAnimalsList; }
			set { TempAnimalsList = value; }
		}
		public int RabbitsStartCount
		{
			get { return rabbitsStartCount; }
			set { rabbitsStartCount = value; }
		}
		public int WolvesStartCount
		{
			get { return wolvesStartCount; }
			set { wolvesStartCount = value; }
		}
		public int ShewolvesStartCount
		{
			get { return shewolvesStartCount; }
			set { shewolvesStartCount = value; }
		}
		public int RabbitIsAdult
		{
			get { return rabbitIsAdult; }
			set { rabbitIsAdult = value; }
		}
		public int WolfIsAdult
		{
			get { return wolfIsAdult; }
			set { wolfIsAdult = value; }
		}
		public int RabbitsDeath
		{
			get { return rabbitsDeath; }
			set { rabbitsDeath = value; }
		}
		public int WolvesDeath
		{
			get { return wolvesDeath; }
			set { wolvesDeath = value; }
		}
		public static int Height
		{
			get { return height; }
		}
		public static int Width
		{
			get { return width; }
		}
	}
}