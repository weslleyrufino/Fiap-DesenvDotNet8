
namespace Fiap_Aula3_CadastroAlunosAPI.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _loggerConfig;
        public static bool Arquivo {  get; set; } = false;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = loggerName;
            _loggerConfig = loggerConfig;
        }

        // O que faz?
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        // Aqui é de fato a implementação do meu log.
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string mensagem = $"Log de Execução { logLevel }: { eventId } - { formatter(state, exception) }";

            if (Arquivo)
                EscreverTextoNoArquivo(mensagem);
            else
                Console.WriteLine(mensagem);
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivo = Environment.CurrentDirectory + @$"\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(caminhoArquivo))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivo));
                File.Create(caminhoArquivo).Dispose();
            }

            using StreamWriter stream = new(caminhoArquivo, true);
            stream.WriteLine(mensagem);
            stream.Close();// importante sempre fechar o arquivo para ele não ficar em memória.
        }
    }
}
