using ColoredBagSlots.Configuration;
using Vintagestory.API.Common;

namespace ColoredBagSlots;

public static class Patches
{
    public static void ApplyPatches(this ICoreAPI api, ColoredBagSlotsConfig config)
    {
        if (config.Bags == null) return;

        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null) continue;
            if (obj.Id == 0) continue;
            if (!obj.IsBackpack()) continue;

            foreach (var bag in config.Bags)
            {
                if (bag.Key == null || bag.Value == null || !obj.WildcardRegexMatch(bag.Key)) continue;
                obj.ChangeAttribute(bag.Value, "backpack", "slotBgColor");
            }
        }
    }

    public static ColoredBagSlotsConfig FillConfigWithBags(this ICoreAPI api, ColoredBagSlotsConfig config)
    {
        foreach (var obj in api.World.Collectibles)
        {
            if (obj.Code == null) continue;
            if (obj.Id == 0) continue;
            if (obj.Attributes == null) continue;
            if (!obj.IsBackpack()) continue;
            if (config.Bags.ContainsKey(obj.Code.ToString())) continue;

            config.Bags.Add(obj.Code.ToString(), obj.GetHexColor() ?? config.Default);
        }

        return config;
    }
}