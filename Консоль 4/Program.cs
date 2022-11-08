{
    internal class Program
    {
        static void Master()
        {
            List<DaybookEntry> daybookEntries = new List<DaybookEntry>();
            daybookEntries.Add(new DaybookEntry("Название запись", "запись."));
            daybookEntries.Add(new DaybookEntry(DateTime.Now.AddDays(9), ""));
            daybookEntries.Add(new DaybookEntry("Текст записи"));
            daybookEntries.Add(new DaybookEntry("Полная записи", DateTime.Now.AddDays(9), ""));

            Daybook daybook = new Daybook(daybookEntries); 
            DaybookMenu menu = new DaybookMenu();
            DateTime selDate = DateTime.Today; int selEntry = 0;
            while (true)
            {
                menu.Update(daybook, selDate, selEntry);
                menu.Draw();
                ConsoleKeyInfo ki = Console.ReadKey(true);
                switch (ki.Key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.Enter:
                        if (selEntry <= daybook.entries.Count)
                            menu.ShowSelectedEntry(daybook, selEntry);
                        Console.ReadKey();
                        break;

                    case ConsoleKey.LeftArrow:
                        selDate = selDate.AddDays(-1);
                        break;
                    case ConsoleKey.RightArrow:
                        selDate = selDate.AddDays(1);
                        break;
                    case ConsoleKey.D:  
                        try
                        {
                            selDate = Convert.ToDateTime(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Неправильная дата!");
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (selEntry > 0)
                            selEntry -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selEntry + 1 < daybook.entries.Count)
                            selEntry += 1;
                        break;
                }
            }
        }
    }

    internal class DaybookMenu
    {
        public DaybookMenu()
        {
        }
    }

    internal class Daybook
    {
        private List<DaybookEntry> daybookEntries;

        public Daybook(List<DaybookEntry> daybookEntries)
        {
            this.daybookEntries = daybookEntries;
        }
    }
}

