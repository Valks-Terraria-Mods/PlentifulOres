using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlentifulOres;

[BackgroundColor(0, 0, 0, 100)]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    // Ores
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Copper;

    [DefaultValue(10)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Silver;

    [DefaultValue(15)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Iron;

    [DefaultValue(20)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Gold;

    [DefaultValue(15)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Crimtane;

    // Gems
    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Diamond;

    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Ruby;

    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Emerald;

    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Sapphire;

    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Topaz;

    [DefaultValue(3)]
    [BackgroundColor(0, 0, 0, 100)]
    [Range(1, 100)]
    public int Amethyst;

    public override void OnLoaded()
    {
        PlentifulOres.Config = this;
    }
}
