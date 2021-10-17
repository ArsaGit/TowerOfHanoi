using System;
using System.Collections.Generic;
using System.Threading;

namespace TowerOfHanoi
{
	class Program
	{
		static void Main(string[] args)
		{
			RunRecursive();
			//RunIterative();
			//RunStack();
		}

		static void ShowPegs(Peg from, Peg to, Peg buf_peg)
		{
			Console.WriteLine("Peg1:");
			from.Print();
			Console.WriteLine("Peg2:");
			buf_peg.Print();
			Console.WriteLine("Peg3:");
			to.Print();
		}

		static void RunRecursive()
		{
			const int N = 8;

			var originalPeg = new Peg(N, true);
			var additionalPeg = new Peg(N);
			var finalPeg = new Peg(N);

			ShowPegs(originalPeg, finalPeg, additionalPeg);

			RecutsiveHanoiTower(N, originalPeg, finalPeg, additionalPeg);

			Console.WriteLine("\nAfter:");
			ShowPegs(originalPeg, finalPeg, additionalPeg);
		}

		static void RecutsiveHanoiTower(int quantity, Peg from, Peg to, Peg buf_peg)
		{
			if (quantity != 0)
			{
				RecutsiveHanoiTower(quantity - 1, from, buf_peg, to);

				Relocate(from, to);

				RecutsiveHanoiTower(quantity - 1, buf_peg, to, from);
			}
		}

		static void RunIterative()
		{
			const int N = 8;

			var originalPeg = new Peg(N, true);
			var additionalPeg = new Peg(N);
			var finalPeg = new Peg(N);

			ShowPegs(originalPeg, finalPeg, additionalPeg);

			IterativeHanoiTower(N, originalPeg, finalPeg, additionalPeg);

			Console.WriteLine("\nAfter:");
			ShowPegs(originalPeg, finalPeg, additionalPeg);
		}

		static void IterativeHanoiTower(int number, Peg from, Peg to, Peg buf_peg)
		{
			int countDisk, counter = 1, count;

			while (counter <= Math.Pow(2, number) - 1)
			{ /* Запускаем цикл повторений */

				if (counter % 2 != 0)
				{ /* На нечетном ходу мы будем трогать только самый маленький диск */
					CarryingOver(number, counter, 1, from, to, buf_peg); /* С помощью этой функции определяем для данного диска перемещение */
				}

				else
				{  /* Определяем диск который нужно переместить на четном ходу */
					count = counter;
					countDisk = 0;

					while (count % 2 == 0)
					{  /* Диск который нужно переместить */
						countDisk++;           /* будет числом деления номера хода на 2 без остатка */
						count = count / 2;
					}
					CarryingOver(number, counter, countDisk + 1, from, to, buf_peg);
				}
				counter++;
			}
		}

		static void CarryingOver(int n, int i, int k, Peg from, Peg to, Peg buf_peg)
		{
			int t;
			Peg pegX, pegY, pegZ;

			if (n % 2 == 0)
			{  /* Определяем порядок осей в зависимости от четности */
				pegX = from;      /* и не четности количества дисков */
				pegY = buf_peg;
				pegZ = to;
			}

			else
			{
				pegX = from;
				pegY = to;
				pegZ = buf_peg;
			}

			/* Номер хода можно представить единственным образом */
			/* как произведение некоего нечетного числа на степень двойки */
			/* k будет номером диска который мы перемещаем */
			t = ((i / Convert.ToInt32(Math.Pow(2, k - 1))) - 1) / 2;

			if (k % 2 != 0)
			{    /* Определяем перемещение дисков  для нечетного хода */

				switch (t % 3)
				{         /* Выбираем перемещение в зависимости от данного условия */
					case 0:
						Relocate(pegX, pegY);
						break;
					case 1:
						Relocate(pegY, pegZ);
						break;
					case 2:
						Relocate(pegZ, pegX);
						break;
				}
			}

			else
			{     /* Определяем перемещение дисков  для чётного хода */

				switch (t % 3)
				{
					case 0:
						Relocate(pegX, pegZ);
						break;
					case 1:
						Relocate(pegZ, pegY);
						break;
					case 2:
						Relocate(pegY, pegX);
						break;
				}
			}
		}

		static void Relocate(Peg from, Peg to)
		{
			to.Add(from.Remove());
		}

		//Later

		static void RunStack()
		{
			const int N = 8;

			Stack<int> stack = new Stack<int>();
		}

		static void FillStack(Stack<int> stack, int n)
		{
			for(int i = n; i > 0; i++)
			{
				stack.Push(i);
			}
		}

		static void StackHanoiTower()
		{

		}
	}
}
