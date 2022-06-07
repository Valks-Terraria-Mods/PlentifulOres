using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlentifulOres;

[BackgroundColor(144, 252, 249)]
[Label("Plentiful Ores Config")]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Ore Amounts")]
    [Label("Copper")]
    [DefaultValue(3)]
    [Range(1, 100)]
    public int Copper;

    [Header("Speed")]
    [Label("Tool Speed")]
    [DefaultValue(1.25f)]
    [Range(1f, 30f)]
    public float PickaxeSpeed;

    public override void OnLoaded()
    {
        PlentifulOres.Config = this;
    }

    public override void OnChanged()
    {
        
    }
}
