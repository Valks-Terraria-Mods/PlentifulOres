using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace PlentifulOres;

[BackgroundColor(0, 0, 0, 200)]
public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [DefaultValue(false)]
    public bool KillingMoonLordSpawnsLuminiteOre;

    [DefaultValue(false)]
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
    public int SpeedX;

    [DefaultValue(0)]
    public int SpeedY;

    [DefaultValue(0)]
    [Range(0, 30)]
    public int AdditionalStrength;

    [DefaultValue(0)]
    [Range(0, 30)]
    public int AdditionalSteps;

    // Ores
    [DefaultValue(0)]
    [Range(0, 100)]
    public int CopperBias;

    [DefaultValue(1)]
    [Range(0, 100)]
    public int SilverBias;

    [DefaultValue(1)]
    [Range(0, 100)]
    public int IronBias;

    [DefaultValue(1)]
    [Range(0, 100)]
    public int GoldBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int CrimtaneBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int CobaltBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int MythrilBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int TitaniumBias;

    // Gems
    [DefaultValue(0)]
    [Range(0, 100)]
    public int DiamondBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int RubyBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int EmeraldBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int SapphireBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int TopazBias;

    [DefaultValue(0)]
    [Range(0, 100)]
    public int AmethystBias;

    public override void OnLoaded()
    {
        PlentifulOres.Config = this;
    }
}
