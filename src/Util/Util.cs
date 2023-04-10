using Newtonsoft.Json.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;

namespace ColoredBagSlots;

public static class Util
{
    public static bool WildcardRegexMatch(this CollectibleObject obj, string key) => WildcardUtil.Match(new AssetLocation(key), obj.Code);
    public static bool IsBackpack(this CollectibleObject obj) => obj?.Attributes?["backpack"]?["quantitySlots"]?.AsInt() > 0;
    public static string GetHexColor(this CollectibleObject obj) => obj?.Attributes?["backpack"]?["slotBgColor"]?.AsString();

    public static void ChangeAttribute(this CollectibleObject obj, object newValue, params string[] path)
    {
        obj.Attributes ??= new JsonObject(new JObject());

        switch (path.Length)
        {
            case 1:
                obj.Attributes.Token[path[0]] = JToken.FromObject(newValue);
                break;
            case 2:
                obj.Attributes.Token[path[0]][path[1]] = JToken.FromObject(newValue);
                break;
        }
    }
}