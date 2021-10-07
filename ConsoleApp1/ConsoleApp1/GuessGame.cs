using System;
namespace classes
{
	class GuessGame
	{
		public int keyin, guess, count, min, max;
		public  GuessGame()
		{
			count = 0;
			min = 0;
			max = 101;

			Random r = new Random();
			guess = r.Next(1, 101);

			Console.WriteLine("\n ===== GusessGame =====\n");

			do
			{
				count += 1;
				Console.Write($" {count}. 猜數字範圍 {min} < ? < {max} :");
				keyin = int.Parse(Console.ReadLine());
				if (keyin >= 1 && keyin < 101)
				{
					if (guess == keyin)
					{
						Console.WriteLine($"\n You Guess! Total counts : {count}");
						break;
					}
					else if (guess < keyin)
					{
						max = keyin;
						Console.Write("number down,");
					}
					else if (guess > keyin)
					{
						min = keyin;
						Console.Write("number up,");
					}
					Console.WriteLine($"You guess {count} counts......");
					Console.WriteLine();
				}
				else
				{
					Console.WriteLine("請輸入提示範圍內的數字!");
				}
			} while (true );
		}
	}
}
