using Exiled.API.Interfaces;
using Exiled.Events.Commands.Reload;
using System.Collections.Generic;
using System.ComponentModel;
using RandomEffectCoinFlip.Items;
using YamlDotNet.Serialization;

namespace RandomEffectCoinFlip
{
    public class Config : IConfig
    {
        [Description("Config for coin effects")]
        public List<StatusEffectCoinItem> RandomCoinEffect { get; set; } = new() { 
            new StatusEffectCoinItem(),
        };


        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}