namespace PlentifulOres;

public class OrePopulator : ModSystem
{
    public override void ModifyWorldGenTasks(
        List<GenPass> tasks, 
        ref double totalWeight)
    {
        int index = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
        if (index != -1)
            tasks.Insert(
                index: index + 1,
                item: new ExampleOrePass(nameof(PlentifulOres), 
                loadWeight: 237.4298f));
    }
}

public class ExampleOrePass : GenPass
{
    readonly List<OreInfo> ores = new()
    {
        { new OreInfo(
            tile: GenVars.copperBar > 0 ? TileID.Copper : TileID.Tin,
            amount: PlentifulOres.Config.CopperBias) },

        { new OreInfo(
            tile: GenVars.silverBar > 0 ? TileID.Silver : TileID.Tungsten,
            amount: PlentifulOres.Config.SilverBias ) },

        { new OreInfo(
            tile: GenVars.ironBar > 0 ? TileID.Iron : TileID.Lead,
            amount: PlentifulOres.Config.IronBias) },

        { new OreInfo(
            tile: GenVars.goldBar > 0 ? TileID.Gold : TileID.Platinum,
            amount: PlentifulOres.Config.GoldBias) },

        { new OreInfo(
            tile: WorldGen.crimson ? TileID.Crimtane : TileID.Demonite,
            amount: PlentifulOres.Config.CrimtaneBias) }
    };

    readonly List<OreInfo> gems = new()
    {
        { new OreInfo(TileID.Diamond, PlentifulOres.Config.DiamondBias) },
        { new OreInfo(TileID.Ruby, PlentifulOres.Config.RubyBias) },
        { new OreInfo(TileID.Emerald, PlentifulOres.Config.EmeraldBias) },
        { new OreInfo(TileID.Sapphire, PlentifulOres.Config.SapphireBias) },
        { new OreInfo(TileID.Amethyst, PlentifulOres.Config.AmethystBias) },
        { new OreInfo(TileID.Topaz, PlentifulOres.Config.TopazBias) }
    };

    public ExampleOrePass(string name, float loadWeight) : 
        base(name, loadWeight) { }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding EVEN MORE ORES!!!! HAHAHAHA!!";

        int tileCount = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);

        for (int k = 0; k < tileCount; k++)
        {
            GenerateOres();
            GenerateGems();
        }
    }

    void GenerateOres()
    {
        foreach (var ore in ores)
            for (int n = 0; n < ore.Amount; n++)
                GenerateTile(ore.Tile);
    }

    void GenerateGems()
    {
        foreach (OreInfo gem in gems)
            for (int n = 0; n < gem.Amount; n++)
                GenerateTile(gem.Tile);
    }

    void GenerateTile(ushort id)
    {
        Config config = PlentifulOres.Config;

        bool nearSurface = config.NearSurface;

        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
        int y = WorldGen.genRand.Next(
            minValue: nearSurface ? (int)GenVars.worldSurfaceLow : (int)GenVars.rockLayerLow, 
            maxValue: Main.maxTilesY);

        int additionalStr = config.AdditionalStrength;
        int additionalSteps = config.AdditionalSteps;

        WorldGen.TileRunner(x, y,
            strength: WorldGen.genRand.Next(10 + additionalStr, 15 + additionalStr),
            steps: WorldGen.genRand.Next(3 + additionalSteps, 6 + additionalSteps),
            type: id,
            addTile: config.NotOnlyReplaceButAdd,
            speedX: config.SpeedX,
            speedY: config.SpeedY,
            noYChange: config.NoYChange,
            overRide: config.Override_OnlyChangeIfYouKnowWhatYouAreDoing);
    }
}

public struct OreInfo
{
    public ushort Tile { get; set; }
    public int Amount { get; set; }

    public OreInfo(ushort tile, int amount = 1)
    {
        Tile = tile;
        Amount = amount;
    }
}
