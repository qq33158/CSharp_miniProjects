using System;
namespace classes
{ 
	class GetMax
	{
		public int max;
		public int Get_Max(ref int[] ary)
		{
			max = ary[0];
			for (int i = 1; i <= ary.GetUpperBound(0); i++)
			{
				if (max < ary[i])
					max = ary[i];
			}
			return max;
		}
	}
}