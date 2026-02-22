using SingletonChallenge;
using SingletonChallenge.Services;

Console.WriteLine("=== Sistema de Configurações ===\n");

// Problema 1: Múltiplas instâncias são criadas
Console.WriteLine("Inicializando serviços...\n");

var dbService = new DatabaseService();
var apiService = new ApiService();
var cacheService = new CacheService();
var logService = new LoggingService();

Console.WriteLine("\nUsando os serviços...\n");

dbService.Connect();
apiService.MakeRequest();
cacheService.Connect();
logService.Log("Sistema iniciado");

// Problema 2: Configurações podem ficar inconsistentes
Console.WriteLine("\n--- Tentativa de atualização ---\n");

var config1 = ConfigurationManager.Instance;
config1.LoadConfigurations();
config1.UpdateSetting("LogLevel", "Debug");

var config2 = ConfigurationManager.Instance;
config2.LoadConfigurations();
Console.WriteLine($"Config1 LogLevel: {config1.GetSetting("LogLevel")}");
Console.WriteLine($"Config2 LogLevel: {config2.GetSetting("LogLevel")}");
Console.WriteLine("⚠️ Inconsistência Resulvida: Mesma instância tem mesmos valores!");

// Problema 3: Desperdício de memória e processamento
Console.WriteLine("\n--- Impacto de Performance ---");
Console.WriteLine("Todos os serviços carregaram a mesma configuração");
Console.WriteLine("Isso economiza memória e tempo de inicialização");
