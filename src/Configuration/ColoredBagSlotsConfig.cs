using System.Collections.Generic;
using Vintagestory.API.Client;
using Vintagestory.API.MathTools;

namespace ColoredBagSlots.Configuration
{
    public class ColoredBagSlotsConfig
    {
        public readonly string Default = ColorUtil.Int2HexBGR(ColorUtil.ColorFromRgba(GuiStyle.DialogSlotBackColor));
        public Dictionary<string, string> Bags = new() { };

        public ColoredBagSlotsConfig() { }
        public ColoredBagSlotsConfig(ColoredBagSlotsConfig previousConfig)
        {
            foreach (var item in previousConfig.Bags)
            {
                if (Bags.ContainsKey(item.Key)) continue;
                Bags.Add(item.Key, item.Value);
            }
        }
    }
}
