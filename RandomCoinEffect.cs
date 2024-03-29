using Exiled.API.Features;
using Exiled.CustomItems.API;
using RandomCoinEffect.Events;
using System;
using System.Linq;
using Player = Exiled.Events.Handlers.Player;

namespace RandomCoinEffect
{
    public class RandomCoinEffect : Plugin<Config>
    {
        public override string Prefix => "coineffect";
        public override string Name => "RandomCoinEffect";
        public override string Author => "Gooseo";
        public override Version Version { get; } = new(1, 0, 0);


        public static RandomCoinEffect Instance { get; private set; } = null!;

        public override void OnEnabled()
        {
            Instance = this;

            Config.RandomCoinEffect.Register();

            Player.Spawned += PlayerHandler.Spawned;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Config.RandomCoinEffect.Unregister();

            Player.Spawned -= PlayerHandler.Spawned;

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
