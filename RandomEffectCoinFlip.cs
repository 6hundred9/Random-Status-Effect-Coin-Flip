using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using RandomEffectCoinFlip.Events;
using System;
using System.Linq;
using thegooseplugin.Events;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace RandomEffectCoinFlip
{
    public class RandomEffectCoinFlip : Plugin<Config>
    {
        private ServerHandler serverHandler = null!;
        public static RandomEffectCoinFlip Instance { get; private set; } = null!;

        public override void OnEnabled()
        {
            Instance = this;
            serverHandler = new ServerHandler();
            Player.Spawned += PlayerHandler.Spawned;

            CustomItem.RegisterItems(overrideClass: Config.RandomCoinEffect);

            Server.ReloadedConfigs += serverHandler.OnReloadingConfigs;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();

            Player.Spawned -= PlayerHandler.Spawned;

            Server.ReloadedConfigs -= serverHandler.OnReloadingConfigs;
            base.OnDisabled();
        }

        public static TEnum GetRandomEnumValue<TEnum>(params TEnum[] excludedValues) where TEnum : struct, Enum
        {
            // Check if TEnum is an enum type
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("Type parameter must be an enum type");
            }

            // Get an array of all enum values excluding excludedValues
            TEnum[] enumValues = Enum.GetValues(typeof(TEnum))
                                      .Cast<TEnum>()
                                      .Where(value => !excludedValues.Contains(value))
                                      .ToArray();

            // Generate a random index within the range of the enumValues array
            int randomIndex = UnityEngine.Random.Range(0, enumValues.Length);

            // Retrieve the enum value at the randomly generated index
            TEnum randomEnumValue = enumValues[randomIndex];

            return randomEnumValue;
        }
    }
}
