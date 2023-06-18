using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlentifulOres;

[BackgroundColor(0, 0, 0, 100)]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    // Ores
    [Header("Ore Amounts")]
    [Label("Copper")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Copper;

    [Header("Ore Amounts")]
    [Label("Silver")]
    [DefaultValue(10)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Silver;

    [Header("Ore Amounts")]
    [Label("Iron")]
    [DefaultValue(15)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Iron;

    [Header("Ore Amounts")]
    [Label("Gold")]
    [DefaultValue(20)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Gold;

    [Header("Ore Amounts")]
    [Label("Crimtane")]
    [DefaultValue(15)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Crimtane;

    // Gems
    [Header("Gem Amounts")]
    [Label("Diamond")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Diamond;

    [Header("Gem Amounts")]
    [Label("Ruby")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Ruby;

    [Header("Gem Amounts")]
    [Label("Emerald")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Emerald;

    [Header("Gem Amounts")]
    [Label("Sapphire")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Sapphire;

    [Header("Gem Amounts")]
    [Label("Topaz")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Topaz;

    [Header("Gem Amounts")]
    [Label("Amethyst")]
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Amethyst;

    public override void OnLoaded()
    {
        PlentifulOres.Config = this;
    }
}
