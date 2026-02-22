namespace SingletonChallenge.Services;

// Serviços da aplicação que precisam das configurações
public class DatabaseService
{
    private readonly ConfigurationManager _config;

    public DatabaseService()
    {
        // Problema: Cada serviço cria sua própria instância
        _config = ConfigurationManager.Instance;
    }

    public void Connect()
    {
        var connectionString = _config.GetSetting("DatabaseConnection");
        Console.WriteLine($"[DatabaseService] Conectando ao banco: {connectionString}");
    }
}

