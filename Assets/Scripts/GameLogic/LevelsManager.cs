using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
public static class LevelsManager
{
    private static string[] _levelKeys;
    private static int _levelIndex = 0;
    private static bool _offline;

    public struct userAttributes{}

    public struct appAttributes{}

    public struct filterAttributes 
    {
        public string[] key;
    }

    public static void WorkInOfflineMode()
    {
        _offline = true;
    }

    private static async UniTask InitializeRemoteConfigAsync()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    public static void LevelWon()
    {
        if (_offline)
            return;

        _levelIndex++;
        if (_levelIndex > _levelKeys.Length - 1)
            _levelIndex = 0;
    }

    public static async UniTask LoadLevelKeys()
    {
        await InitializeRemoteConfigAsync();

        RemoteConfigService.Instance.FetchCompleted += FetchLevelsKeys;

        var fAttributes = new filterAttributes();
        fAttributes.key = new string[] { "Levels" };
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes(), fAttributes);
    }

    public static async UniTask<LevelInfo> LoadLevelInfo()
    {
        if (_offline)
        {
            string[] wordsToGuess = new string[] { "Молоко", "Воздух", "Дерево", "Лопата" };
            string[] containers = new string[] { "Мо", "локо", "Во", "зд", "ух", "Де", "ре", "во", "Лоп", "ата" };
            return new LevelInfo(wordsToGuess, containers);
        }

        var fAttributes = new filterAttributes();
        fAttributes.key = new string[] { _levelKeys[_levelIndex] };
        var response = await RemoteConfigService.Instance.FetchConfigsAsync(new userAttributes(), new appAttributes(), fAttributes);
        
        return FetchLevelInfo(response);
    }

    private static LevelInfo FetchLevelInfo(RuntimeConfig _)
    {
        return JsonConvert.DeserializeObject<LevelInfo>(RemoteConfigService.Instance
            .GetConfig("settings").GetJson(_levelKeys[_levelIndex]));
    }

    private static void FetchLevelsKeys(ConfigResponse _)
    {
        RemoteConfigService.Instance.FetchCompleted -= FetchLevelsKeys;
        _levelKeys = JsonConvert.DeserializeObject<LevelKeys>(RemoteConfigService.Instance
            .GetConfig("settings")
            .GetJson("Levels"))
            .levelKeys;
    }
}
