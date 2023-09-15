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
                item: new PrehardmodeOresPass(nameof(PlentifulOres), 
                loadWeight: 237.4298f));
    }

    public override void ModifyHardmodeTasks(List<GenPass> tasks)
    {
        int index = tasks.FindIndex(genpass => genpass.Name.Equals("Hardmode Good"));
        if (index != -1)
            tasks.Insert(
                index: index + 1,
                item: new HardmodeOresPass(nameof(PlentifulOres),
                loadWeight: 237.4298f));
    }
}

public class HardmodeOresPass : GenPass
{
    readonly List<OreInfo> ores = new()
    {
        { new OreInfo(
            tile: TileID.Cobalt,
            amount: PlentifulOres.Config.CobaltBias) },
        
        { new OreInfo(
            tile: TileID.Mythril,
            amount: PlentifulOres.Config.MythrilBias) },
        
        { new OreInfo(
            tile: TileID.Titanium,
            amount: PlentifulOres.Config.TitaniumBias) },
    };

    public HardmodeOresPass(string name, float loadWeight) :
        base(name, loadWeight) { }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        int tileCount = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);

        for (int k = 0; k < tileCount; k++)
        {
            GenerateOres();
        }
    }

    void GenerateOres()
    {
        foreach (var ore in ores)
            for (int n = 0; n < ore.Amount; n++)
                Utils.GenerateHardmodeTile(ore.Tile);
    }
}

public class PrehardmodeOresPass : GenPass
{
    readonly List<OreInfo> ores = new()
    {
        { new OreInfo(
            tile: GenVars.copperBar,
            amount: PlentifulOres.Config.CopperBias) },

        { new OreInfo(
            tile: GenVars.silverBar,
            amount: PlentifulOres.Config.SilverBias ) },

        { new OreInfo(
            tile: GenVars.ironBar,
            amount: PlentifulOres.Config.IronBias) },

        { new OreInfo(
            tile: GenVars.goldBar,
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

    public PrehardmodeOresPass(string name, float loadWeight) : 
        base(name, loadWeight) { }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding EVEN MORE ORES!!!!";

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
                Utils.GenerateTile(ore.Tile);
    }

    void GenerateGems()
    {
        foreach (OreInfo gem in gems)
            for (int n = 0; n < gem.Amount; n++)
                Utils.GenerateTile(gem.Tile);
    }
}

public struct OreInfo
{
    public int Tile { get; set; }
    public int Amount { get; set; }

    public OreInfo(int tile, int amount = 1)
    {
        Tile = tile;
        Amount = amount;
    }
}
