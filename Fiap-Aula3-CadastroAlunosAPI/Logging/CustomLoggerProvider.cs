using System.Collections.Concurrent;

namespace Fiap_Aula3_CadastroAlunosAPI.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly CustomLoggerProviderConfiguration _loggerConfig;
        private readonly ConcurrentDictionary<string, CustomLogger> loggers = new ConcurrentDictionary<string, CustomLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerConfig = loggerConfig;
        }

        // Create Logger: Vai permitir que eu consiga criar um log para uma categoria específica, permitindo uma segmentação eficiente e organizada dos logs, facilitando a rastreabilidade e análise dos nossos registros.
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomLogger(name, _loggerConfig));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
