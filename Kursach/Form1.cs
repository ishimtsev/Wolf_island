using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
	public partial class Form1 : Form
	{
		Map MAP = new Map();
		PictureBox[,] space = new PictureBox[Map.Width, Map.Height];
		public Form1()
		{
			InitializeComponent();

			for (int i = 0; i < Map.Width; i++)
			{
				for (int j = 0; j < Map.Height; j++)
				{
					space[i, j] = new PictureBox();
					space[i, j].Size = new System.Drawing.Size(60, 36);
					space[i, j].Location = new System.Drawing.Point(i * 60 + 170, j * 36 + 20);
					space[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
					space[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					space[i, j].Tag = i * 20 + j;
					space[i, j].BackColor = System.Drawing.SystemColors.ControlLightLight;
					space[i, j].MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
					space[i, j].MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
					this.Controls.Add(space[i, j]);
				}
			}
			SpawnAnimals();
			Refresh();
		}
		public void Refresh() //обновление игрового поля и вывод его на экран
		{
			int count = 0; //общее кол-во зверей в клетке
			int[] type = { 0, 0, 0, 0 }; //типы животных: волк, волчонок, кролик, крольчонок
			for (int i = 0; i < Map.Width; i++)
			{
				for (int j = 0; j < Map.Height; j++)
				{
					for (int k = 0; k < 4; k++) //обнуление временной переменной
						type[k] = 0;
					count = 0;
					foreach (Animal animal in MAP.animalsList) //цикл по списку животных
					{
						if (animal.coordX == i && animal.coordY == j) //если координаты животного и клетки совпадают
						{
							if (animal.GetType() == typeof(Rabbit)) //если животное - это кролик
							{
								if (animal.age <= MAP.RabbitIsAdult) //если это крольчонок
								{
									type[3]++;
									count++;
									continue;
								}
								type[2]++; //если это кролик
								count++;
							}
							else if (animal.GetType() == typeof(Wolf) || animal.GetType() == typeof(Shewolf)) //если животное - это волк или волчица
							{
								if (animal.age <= MAP.WolfIsAdult) //если это волчонок
								{
									type[1]++;
									count++;
									continue;
								}
								type[0]++; //если это волк
								count++;
							}
						}
					}
					if (count > 0) //если в клетке есть животные, выбирается картинка для отображения в клетке
					{
						if ((type[0] > 0 || type[1] > 0) && (type[2] > 0 || type[3] > 0)) //если в клетке разные животные
						{
							space[i, j].Image = global::Kursach.Properties.Resources.wolf_and_rabbit;
							continue;
						}
						else if (type[0] > 0) //если в клетке волки и возможно волчата
						{
							space[i, j].Image = global::Kursach.Properties.Resources.wolf;
							continue;
						}
						else if (type[1] > 0) //если в клетке только волчата
						{
							space[i, j].Image = global::Kursach.Properties.Resources.lil_wolf;
							continue;
						}
						else if (type[2] > 0) //если в клетке кролики и возможно крольчата
						{
							space[i, j].Image = global::Kursach.Properties.Resources.rabbit;
							continue;
						}
						else //если в клетке только крольчата
						{
							space[i, j].Image = global::Kursach.Properties.Resources.lil_rabbit;
							continue;
						}
					}
					else
						space[i, j].Image = null; //если в клетке нет животных, она отображается пустой
				}
			}
			//далее идёт вывод общего количества животных на игровом поле и количества каждого вида животных отдельно
			int rabbits_count = 0, wolves_count = 0, shewolves_count = 0; //создание переменных для подсчёта животных
			count = 0;
			foreach (Animal animal in MAP.animalsList)
			{
				count++; //считается общее количество животных
				if (animal.GetType() == typeof(Rabbit)) //количество кроликов
					rabbits_count++;
				if (animal.GetType() == typeof(Wolf)) //количество волков
					wolves_count++;
				if (animal.GetType() == typeof(Shewolf)) //количество волчиц
					shewolves_count++;
			}
			InfoLabel.Text = "Общее количество животных: " + count + " \nКроликов: " + rabbits_count 
				+ " \nВолков: " + wolves_count + " \nВолчиц: " + shewolves_count; //вывод информации на экран
		}
		void SpawnAnimals() //генерация животных
		{
			for (int i = 0; i < MAP.RabbitsStartCount; i++)
			{
				Rabbit t = new Rabbit(random.Next(Map.Height), random.Next(Map.Width)); //создание объекта класса "Кролик" со случайными координатами
				t.age = MAP.RabbitIsAdult + 1; //присвоение возраста
				MAP.animalsList.Add(t); //добавление в общий список животных
			}
			for (int i = 0; i < MAP.WolvesStartCount; i++)
			{
				Wolf t = new Wolf(random.Next(Map.Height), random.Next(Map.Width)); //создание объекта класса "Волк" со случайными координатами
				t.age = MAP.WolfIsAdult + 1; //присвоение возраста
				MAP.animalsList.Add(t); //добавление в общий список животных
			}
			for (int i = 0; i < MAP.ShewolvesStartCount; i++)
			{
				Shewolf t = new Shewolf(random.Next(Map.Width), random.Next(Map.Height)); //создание объекта класса "Волчица" со случайными координатами
				t.age = MAP.WolfIsAdult + 1; //присвоение возраста
				MAP.animalsList.Add(t); //добавление в общий список животных
			}
		}
		void Turn()
		{
			MAP.Turn();
			Refresh();
		}
		private void TurnButton_Click(object sender, EventArgs e)
		{
			if (TurningTimer.Enabled)
			{
				TurningTimer.Enabled = false;
			}
			else
			{
				Turn();
			}
		}

		private void StartStopButton_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = !TurningTimer.Enabled;
		}

		private void RestartButton_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = false;
			MAP.animalsList.Clear();
			SpawnAnimals();
			Refresh();
		}

		private void TurningTimer_Tick(object sender, EventArgs e)
		{
			Turn();
		}
		private void pictureBox_MouseEnter(object sender, EventArgs e)
		{
			if (!TurningTimer.Enabled)
			{
				PictureBox picturebox = sender as PictureBox;
				int x = (int)picturebox.Tag / Map.Height;
				int y = (int)picturebox.Tag % Map.Height;
				string line = "";
				int count = 0;
				foreach (Animal animal in MAP.animalsList)
				{
					if (animal.coordX == x && animal.coordY == y)
					{
						count++;
						if (animal.GetType() == typeof(Rabbit))
						{
							Rabbit rabbit = animal as Rabbit;
							line += "  Кролик       Возраст: " + rabbit.age + "\n";
						}
						if (animal.GetType() == typeof(Wolf))
						{
							Wolf wolf = animal as Wolf;
							line += "  Волк       Возраст: " + wolf.age + "   Сытость: " + wolf.hunger + "\n";
						}
						if (animal.GetType() == typeof(Shewolf))
						{
							Shewolf shewolf = animal as Shewolf;
							if (shewolf.pregnancy > 0)
								line += "  Волчица       Возраст: " + shewolf.age + "   Сытость: " + shewolf.hunger + "   Беременность: " + shewolf.pregnancy + "\n";
							else
								line += "  Волчица       Возраст: " + shewolf.age + "   Сытость: " + shewolf.hunger + "   Не беременна" + "\n";
						}
					}
				}
				if (count == 0)
					toolTip1.SetToolTip(space[x, y], "В этой клетке нет животных");
				else
					toolTip1.SetToolTip(space[x, y], "Всего животных в клетке: " + count + " \n" + line);
			}
		}
		private void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			PictureBox picturebox = sender as PictureBox;
			int x = (int)picturebox.Tag / Map.Height;
			int y = (int)picturebox.Tag % Map.Height;

			if (e.Button == MouseButtons.Left)
			{
				Rabbit t = new Rabbit(x, y);
				t.age = MAP.RabbitIsAdult + 1;
				MAP.animalsList.Add(t);
				Refresh();
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (random.Next(2) == 0) //выбор пола волчонка
				{
					Wolf t = new Wolf(x, y);
					t.age = MAP.WolfIsAdult + 1;
					MAP.animalsList.Add(t);
					Refresh();
				}
				else
				{
					Shewolf t = new Shewolf(x, y);
					t.age = MAP.WolfIsAdult + 1;
					MAP.animalsList.Add(t);
					Refresh();
				}
			}
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			TurningTimer.Enabled = false;
			Settings form = new Settings();
			form.textBox1.Text = MAP.RabbitsStartCount.ToString();
			form.textBox2.Text = MAP.WolvesStartCount.ToString();
			form.textBox3.Text = MAP.ShewolvesStartCount.ToString();
			form.textBox4.Text = MAP.RabbitIsAdult.ToString();
			form.textBox5.Text = MAP.WolfIsAdult.ToString();
			form.textBox6.Text = MAP.RabbitsDeath.ToString();
			form.textBox7.Text = MAP.WolvesDeath.ToString();
			if (form.ShowDialog() == DialogResult.OK)
			{
				try
				{
					MAP.RabbitsStartCount = int.Parse(form.textBox1.Text);
					MAP.WolvesStartCount = int.Parse(form.textBox2.Text);
					MAP.ShewolvesStartCount = int.Parse(form.textBox3.Text);
					MAP.RabbitIsAdult = int.Parse(form.textBox4.Text);
					MAP.WolfIsAdult = int.Parse(form.textBox5.Text);
					MAP.RabbitsDeath = int.Parse(form.textBox6.Text);
					MAP.WolvesDeath = int.Parse(form.textBox7.Text);

					RestartButton_Click(sender, e);
				}
				catch (Exception er)
				{
					MessageBox.Show(er.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}