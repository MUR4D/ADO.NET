static class Menu
    {

        public static T MainDraw<T>(List<T> items)
        {
            dynamic ret=0;
            int choose = 0;
            while (true)
            {

                Console.SetCursorPosition(0, 10);
                for (int i = 0; i < items.Count; i++)
                {
                    if (choose == i) Console.BackgroundColor = ConsoleColor.Red;




                    Console.WriteLine($"{i + 1}-{items[i]}");
                    Console.ResetColor();

                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (choose < items.Count - 1) choose++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choose > 0) choose--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                         ret = items[choose];
                        return ret;
                    case ConsoleKey.Escape:
                    Console.Clear();
                    ret = "0"; 
                    return ret;
                    break;
                    default:
                    
                        break;
                }

            }

        }

       
        
    }