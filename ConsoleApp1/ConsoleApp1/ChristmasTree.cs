using System;
namespace classes
{
    class ChristmaxsTree
    {
        public int treelong;
        public ChristmaxsTree()
        {
            Console.Write("請輸入要幾層的聖誕樹: ");
            treelong = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= treelong; i++)
            {
                for (int j = 0; j < treelong - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i * 2 - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}