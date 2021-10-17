using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
	public class Peg
	{
		public List<int> Rings { get; set; }

		public Peg(int size, bool isFirst = false)
		{
			Rings = new List<int>(size);
			if (isFirst) FillPeg(Rings);
		}

		private void FillPeg(List<int> rings)
		{
			for(int i = rings.Capacity; i > 0; i--)
			{
				rings.Add(i);
			}
		}

		public int Remove()
		{
			int ring = Rings[Rings.Count - 1];
			Rings.RemoveAt(Rings.Count - 1);
			return ring;
		}

		public void Add(int ring)
		{
			Rings.Add(ring);
		}

		public void Print()
		{
			foreach (var e in Rings)
			{
				Console.Write("{0} ", e);
			}
			Console.Write('\n');
		}
	}
}
