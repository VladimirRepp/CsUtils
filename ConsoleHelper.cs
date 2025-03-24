namespace Utils
{
    public static class ConsoleHelper
    {
        public static void EnterForContinued()
        {
            Console.WriteLine("Нажмите ВВОД для продолжения ...");
            Console.ReadLine();
        }

        public static bool IsExit() {
            string command = ConsoleCommands.COMMANDS[-1];

            Console.WriteLine($"Для выхода введите: {command}");
            string input = Console.ReadLine();

            return ConsoleCommands.CheckCommand(-1, input);
        }
    }
}
