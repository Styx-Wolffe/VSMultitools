using System;
using Multitools.Configuration;
using Vintagestory.API.Common;

namespace Multitools
{
    public class MultitoolsModSystem : ModSystem
    {
        private ICoreAPI api;
        public Config Config { get; set; }

        public override void StartPre(ICoreAPI api)
        {
            base.StartPre(api);
            this.api = api;
            this.Config = ModConfig.ReadConfig<Config>(api, "MultitoolsConfig.json");
            api.World.Config.SetBool("Multitools.Trader.Enabled.SurvivalGoods", this.Config.TraderEnabled["survivalgoods"]);
            api.World.Config.SetBool("Multitools.Trader.Enabled.BuildMaterials", this.Config.TraderEnabled["buildmaterials"]);
            api.World.Config.SetBool("Multitools.Trader.Enabled.TreasureHunter", this.Config.TraderEnabled["treasurehunter"]);

            ModConfig.WriteConfig(api, "MultitoolsConfig.json", this.Config);
        }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.Logger.Notification("[Multitools] has loaded!");
            base.Mod.Logger.Notification("Side has loaded: " + api.Side.ToString());
            api.RegisterItemClass("ItemPaxel", typeof(ItemPaxel));
            api.RegisterItemClass("ItemHythe", typeof(ItemHythe));
        }
    }
}