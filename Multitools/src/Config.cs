using System;
using System.Collections.Generic;
using Vintagestory.API.Common;

namespace Multitools.Configuration
{
    public class Config : IModConfig
    {
        public Dictionary<string,bool> TraderEnabled { get; set; }
        public Config()
        {
            TraderEnabled = new Dictionary<string, bool>
            {
                { "buildmaterials", true },
                { "survivalgoods", true },
                { "treasurehunter", true }
            };
        }
        public Config(ICoreAPI api, Config previousConfig = null)
        {
            TraderEnabled = new Dictionary<string, bool>();

            if (previousConfig != null)
            {
                foreach (var kvp in previousConfig.TraderEnabled)
                {
                    TraderEnabled[kvp.Key] = kvp.Value;
                }
            }
            else
            {
                TraderEnabled["buildmaterials"] = true;
                TraderEnabled["survivalgoods"] = true;
                TraderEnabled["treasurehunter"] = true;
            }
        }
    }
}
