using Vintagestory.API.Common;

namespace ColoredBagSlots.Configuration;

static class ModConfig
{
    private const string jsonConfig = "ColoredBagSlotsConfig.json";
    private static ColoredBagSlotsConfig config;

    public static void ReadConfig(ICoreAPI api)
    {
        try
        {
            config = LoadConfig(api);
            config = api.FillConfigWithBags(config);

            if (config == null)
            {
                GenerateConfig(api);
                config = LoadConfig(api);
                config = api.FillConfigWithBags(config);
            }
            else
            {
                GenerateConfig(api, config);
                config = api.FillConfigWithBags(config);
            }
        }
        catch
        {
            GenerateConfig(api);
            config = LoadConfig(api);
            config = api.FillConfigWithBags(config);
        }

        api.ApplyPatches(config);
    }

    private static ColoredBagSlotsConfig LoadConfig(ICoreAPI api) => api.LoadModConfig<ColoredBagSlotsConfig>(jsonConfig);
    private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new ColoredBagSlotsConfig(), jsonConfig);
    private static void GenerateConfig(ICoreAPI api, ColoredBagSlotsConfig previousConfig) => api.StoreModConfig(new ColoredBagSlotsConfig(previousConfig), jsonConfig);
}