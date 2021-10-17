using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
	class Program
	{
		static void Main(string[] args)
		{
			RunRecursive();
		}

		static void RunRecursive()
		{
			const int N = 8;

			var originalPeg = new Peg(N, true);
			var additionalPeg = new Peg(N);
			var finalPeg = new Peg(N);

			RecutsiveHanoiTower(N, originalPeg, finalPeg, additionalPeg);

			finalPeg.Print();
		}

		static void RecutsiveHanoiTower(int quantity, Peg from, Peg to, Peg buf_peg)
		{
			if (quantity != 0)
			{
				RecutsiveHanoiTower(quantity - 1, from, buf_peg, to);

				to.Add(from.Remove());

				RecutsiveHanoiTower(quantity - 1, buf_peg, to, from);
			}
		}


	}
}
