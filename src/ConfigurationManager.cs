namespace SingletonChallenge;

using SingletonChallenge.Services;

public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance = 
        new (() => new ConfigurationManager());
    
    public static ConfigurationManager Instance => _instance.Value;

    private Dictionary<string, string> _settings;
    private bool _isLoaded;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
        _isLoaded = false;
        Console.WriteLine("⚠️ Nova instância de ConfigurationManager criada!");
    }

    public void LoadConfigurations()
    {
        if (_isLoaded)
        {
            Console.WriteLine("Configurações já carregadas.");
            return;
        }

        Console.WriteLine("🔄 Carregando configurações...");
        
        // Simulando operação custosa de carregamento
        System.Threading.Thread.Sleep(200);

        // Carregando configurações de diferentes fontes
        _settings["DatabaseConnection"] = "Server=localhost;Database=MyApp;";
        _settings["ApiKey"] = "abc123xyz789";
        _settings["CacheServer"] = "redis://localhost:6379";
        _settings["MaxRetries"] = "3";
        _settings["TimeoutSeconds"] = "30";
        _settings["EnableLogging"] = "true";
        _settings["LogLevel"] = "Information";

        _isLoaded = true;
        Console.WriteLine("✅ Configurações carregadas com sucesso!\n");
    }

    public string? GetSetting(string key)
    {
        if (!_isLoaded)
            LoadConfigurations();

        if (_settings.ContainsKey(key))
            return _settings[key];

        return null;
    }

    public void UpdateSetting(string key, string value)
    {
        _settings[key] = value;
        Console.WriteLine($"Configuração atualizada: {key} = {value}");
    }
}


