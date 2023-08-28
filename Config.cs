using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlentifulOres;

[BackgroundColor(0, 0, 0, 200)]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [DefaultValue(true)]
    public bool KillingMoonLordSpawnsLuminiteOre;

    [DefaultValue(true)]
    public bool FastChlorophyte;

    [DefaultValue(false)]
    public bool NearSurface;

    [DefaultValue(false)]
    public bool NotOnlyReplaceButAdd;

    [DefaultValue(false)]
    public bool NoYChange;

    [DefaultValue(true)]
    public bool Override_OnlyChangeIfYouKnowWhatYouAreDoing;

    [DefaultValue(0)]
    [Range(0, 10000)]
    public float SpeedX;

    [DefaultValue(0)]
    [Range(0, 10000)]
    public float SpeedY;

    [DefaultValue(0)]
    [Range(0, 30)]
    public int AdditionalStrength;

    [DefaultValue(0)]
    [Range(0, 30)]
    public int AdditionalSteps;

    // Ores
    [DefaultValue(3)]
    [Range(0, 100)]
    public int CopperBias;

    [DefaultValue(10)]
    [Range(0, 100)]
    public int SilverBias;

    [DefaultValue(15)]
    [Range(0, 100)]
    public int IronBias;

    [DefaultValue(20)]
    [Range(0, 100)]
    public int GoldBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int CrimtaneBias;

    [DefaultValue(15)]
    [Range(0, 100)]
    public int CobaltBias;

    [DefaultValue(15)]
    [Range(0, 100)]
    public int MythrilBias;

    [DefaultValue(15)]
    [Range(0, 100)]
    public int TitaniumBias;

    // Gems
    [DefaultValue(3)]
    [Range(0, 100)]
    public int DiamondBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int RubyBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int EmeraldBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int SapphireBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int TopazBias;

    [DefaultValue(3)]
    [Range(0, 100)]
    public int AmethystBias;

    public override void OnLoaded()
    {
        PlentifulOres.Config = this;
    }
}
