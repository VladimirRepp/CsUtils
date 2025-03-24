namespace Utils
{
    /// <summary>
    /// Простой логгер потокобезопасный одиначка, для логгирования в текстовый файл и консольный вывод
    /// </summary>
    public class Logger
    {
        private static Logger INSTANCE;
        private static readonly object PADLOCK = new object();

        private string _logFilePath = "log.txt";

        public static Logger Instance
        {
            get
            {
                lock (PADLOCK)
                {
                    if (INSTANCE == null)
                    {
                        INSTANCE = new Logger();
                    }
                }

                return INSTANCE;
            }
        }
        public string LogFilePath { get => _logFilePath; set => _logFilePath = value; }

        private Logger()
        {

        }

        public void Log(string message, string logFilePath, LogLevel level = LogLevel.Info)
        {
            _logFilePath = logFilePath;
            Log(message, level);
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}]: {message}";

            Console.WriteLine(logMessage);

            try
            {
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в лог-файл: {ex.Message}");
            }
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
