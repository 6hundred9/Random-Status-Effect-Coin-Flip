using InventorySystem.Items.Usables.Scp330;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using UnityEngine;
using System;
using MEC; 

using Random = UnityEngine.Random;
using Exiled.API.Features.Items;
using Exiled.CustomItems.API.Features;
using Exiled.API.Features;

namespace RandomEffectCoinFlip.Events
{
    public class PlayerHandler
    {
        public static void Spawned(SpawnedEventArgs ev)
        {
            if (ev.Player.IsScp || !ev.Reason.Equals(SpawnReason.RoundStart))
                return;

            if (!CustomItem.TryGive(ev.Player, 1))
            {
                Log.Debug("it didnt work lmfao");
            }
        }
    }
}
