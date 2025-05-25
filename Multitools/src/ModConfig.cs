using System;
using Vintagestory.API.Common;

namespace Multitools.Configuration
{
    public static class ModConfig
    {
        public static void WriteConfig<C>(ICoreAPI api, string jsonConfig, C config) where C : class, IModConfig
        {
            ModConfig.GenerateConfig<C>(api, jsonConfig, config);
        }

        public static C ReadConfig<C>(ICoreAPI api, string jsonConfig) where C : class, IModConfig
        {
            C c;
            try
            {
                c = ModConfig.LoadConfig<C>(api, jsonConfig);
                if (c == null)
                {
                    ModConfig.GenerateConfig<C>(api, jsonConfig, default(C));
                    c = ModConfig.LoadConfig<C>(api, jsonConfig);
                }
                else
                {
                    ModConfig.GenerateConfig<C>(api, jsonConfig, c);
                }
            }
            catch
            {
                ModConfig.GenerateConfig<C>(api, jsonConfig, default(C));
                c = ModConfig.ReadConfig<C>(api, jsonConfig);
            }
            return c;
        }

        private static C LoadConfig<C>(ICoreAPI api, string jsonConfig) where C : class, IModConfig
        {
            return api.LoadModConfig<C>(jsonConfig);
        }

        private static void GenerateConfig<C>(ICoreAPI api, string jsonconfig, C previousConfig = default(C)) where C : class, IModConfig
        {
            api.StoreModConfig<C>(ModConfig.CloneConfig<C>(api, previousConfig), jsonconfig);
        }

        private static C CloneConfig<C>(ICoreAPI api, C config = default(C)) where C : class, IModConfig
        {
            return (C)((object)Activator.CreateInstance(typeof(C), new object[]
            {
                api,
                config
            }));
        }
    }
}
