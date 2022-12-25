namespace ConsoleChristmasTree
{
    public static class ChristmasTree
    {
        private const int CHRISTMAS_TREE_SIZE = 9;
        public static void StartLights()
        {
            while (true)
            {
                PrintStar();
                PrintLeafs();
                PrintRoot();
                ResetConsoleColor();
                PrintMessage();
                Thread.Sleep(350);
                Console.Clear();
            }
        }

        private static void PrintStar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(new string(' ', CHRISTMAS_TREE_SIZE) + "*");
        }

        private static void PrintLeafs()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 1; i <= CHRISTMAS_TREE_SIZE; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine(new string(' ', CHRISTMAS_TREE_SIZE) + new string('*', i));
                    continue;
                }

                for (int indent = 0; indent < CHRISTMAS_TREE_SIZE + 1 - i; indent++)
                {
                    Console.Write(' ');
                }

                Random r = new Random();
                int[] lightsIndexes = new int[i / 2];

                for (int lights = 0; lights < lightsIndexes.Length; lights++)
                {
                    lightsIndexes[lights] = r.Next(0, i * 2);
                }

                lightsIndexes = lightsIndexes.OrderBy(x => x).ToArray();

                bool areLightsPlaced = false;
                int lightsCounter = 0;

                for (int tree = 0; tree < i * 2 - 1; tree++)
                {
                    if (!areLightsPlaced && lightsIndexes.Length > 0)
                    {
                        if (lightsIndexes[lightsCounter] == tree)
                        {
                            if (tree % 3 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                            else if (tree % 2 == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.Write('*');
                            Console.ForegroundColor = ConsoleColor.Green;
                            lightsCounter++;

                            if (lightsCounter == lightsIndexes.Length)
                            {
                                areLightsPlaced = true;
                            }

                            continue;
                        }
                    }

                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }

        private static void PrintRoot()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(new string(' ', CHRISTMAS_TREE_SIZE) + "|");
        }

        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintMessage()
        {
            Random r = new Random();
            Console.ForegroundColor = (ConsoleColor)r.Next(1, 15);
            Console.WriteLine();
            Console.WriteLine(new string(' ', 2) + "Merry Christmas!");
        }
    }
}
