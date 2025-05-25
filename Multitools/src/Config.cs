using System;
using System.Collections.Generic;
using Vintagestory.API.Common;

namespace Multitools.Configuration
{
    public class Config : IModConfig
    {
        public Config(ICoreAPI api, Config previousConfig = null)
        {
            if (previousConfig == null)
            {
                return;
            }
            this.TraderEnabled["buildmaterials"] = (!previousConfig.TraderEnabled["buildmaterials"] || previousConfig.TraderEnabled["buildmaterials"]);
            this.TraderEnabled["survivalgoods"] = (!previousConfig.TraderEnabled["survivalgoods"] || previousConfig.TraderEnabled["survivalgoods"]);
            this.TraderEnabled["treasurehunter"] = (!previousConfig.TraderEnabled["treasurehunter"] || previousConfig.TraderEnabled["treasurehunter"]);
        }

        public Dictionary<string, bool> TraderEnabled = new Dictionary<string, bool>
        {
            {
                "buildmaterials",
                true
            },
            {
                "survivalgoods",
                true
            },
            {
                "treasurehunter",
                true
            }
        };
    }
}
