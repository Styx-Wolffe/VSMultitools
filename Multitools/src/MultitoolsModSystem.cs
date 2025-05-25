using System;
using Multitools.Configuration;
using Vintagestory.API.Common;

namespace Multitools
{
    public class MultitoolsModSystem : ModSystem
    {

        public Config Config { get; set; }

        public override void StartPre(ICoreAPI api)
        {
            base.StartPre(api);
            this.Config = ModConfig.ReadConfig<Config>(api, "MultitoolsConfig.json");
            api.World.Config.SetBool("Multitools.Trader.Enabled.SurvivalGoods", this.Config.TraderEnabled["survivalgoods"]);
            api.World.Config.SetBool("Multitools.Trader.Enabled.BuildMaterials", this.Config.TraderEnabled["buildmaterials"]);
            api.World.Config.SetBool("Multitools.Trader.Enabled.TreasureHunter", this.Config.TraderEnabled["treasurehunter"]);
        }

        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.Logger.Notification("Multitools has loaded!");
            base.Mod.Logger.Notification("Hello from template mod: " + api.Side.ToString());
            api.RegisterItemClass("ItemPaxel", typeof(ItemPaxel));
        }
    }
}