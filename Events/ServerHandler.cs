using static RandomEffectCoinFlip;

namespace thegooseplugin.Events
{
    public class ServerHandler
    {
        public void OnReloadingConfigs()
        {
            Instance.Config.LoadItems();
        }
    }
}
