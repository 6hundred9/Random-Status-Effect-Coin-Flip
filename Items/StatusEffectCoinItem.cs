using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Player = Exiled.Events.Handlers.Player;

namespace RandomEffectCoinFlip.Items
{
    public class StatusEffectCoinItem : CustomItem
    {
        public override uint Id { get; set; } = 1;
        public override string Name { get; set; } = "Random Coin Effect";
        public override string Description { get; set; } = "Risk a coinflip for a status effect that lasts 1 minute.";
        public override float Weight { get; set; } = 0.0025f;
        public override SpawnProperties? SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 15,
            DynamicSpawnPoints = new System.Collections.Generic.List<DynamicSpawnPoint> { 
                new()
                {
                    Chance = 100,
                    Location = SpawnLocationType.Inside330Chamber,
                },
                new()
                {
                    Chance = 70,
                    Location = SpawnLocationType.InsideLocker
                }
                
            }
        };
       

        protected override void SubscribeEvents()
        {
            Player.FlippingCoin += OnFlippingCoin;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Player.FlippingCoin -= OnFlippingCoin;
            base.UnsubscribeEvents();
        }

        private void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem))
                return;


            EffectType effectType = RandomEffectCoinFlip.GetRandomEnumValue(EffectType.None);

            ev.Player.EnableEffect(effectType, 10, true);

            ev.Item.Destroy();
        }
    }
}
