using System;
using Vintagestory.API.Common;

namespace Multitools.Configuration
{
    public static class ModConfig
    {
        public static void WriteConfig<C>(ICoreAPI api, string jsonConfig, C config) where C : class, IModConfig
        {
            if (config != null)
            {
                api.StoreModConfig(config, jsonConfig);
            }
        }

        public static C ReadConfig<C>(ICoreAPI api, string jsonConfig) where C : class, IModConfig
        {
            C config = null;
            try
            {
                config = api.LoadModConfig<C>(jsonConfig);
                if (config == null)
                {
                    config = (C)Activator.CreateInstance(typeof(C), new object[] { api, null });
                    api.StoreModConfig(config, jsonConfig);
                }
                else
                {
                    config = (C)Activator.CreateInstance(typeof(C), new object[] { api, config });
                    api.StoreModConfig(config, jsonConfig);
                }
            }
            catch (Exception e)
            {
                api.Logger.Error("[Multitools] Error loading config file: {0}", e.Message);
                config = (C)Activator.CreateInstance(typeof(C), new object[] { api, null });
            }
            return config;
        }
    }
}
