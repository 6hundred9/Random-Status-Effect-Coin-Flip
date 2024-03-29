using Exiled.API.Interfaces;
using RandomCoinEffect.Items;
using System.ComponentModel;

namespace RandomCoinEffect
{
    public class Config : IConfig
    {

        [Description("Config for coin effects")]
        public CoinItem RandomCoinEffect { get; set; } = new();

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}