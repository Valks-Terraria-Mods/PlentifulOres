namespace PlentifulOres;

public class OrePopulator : ModSystem
{
    readonly List<OreInfo> ores = new()
    {
        { new OreInfo(
            tile: GenVars.copperBar > 0 ? TileID.Copper : TileID.Tin, 
            amount: PlentifulOres.Config.Copper) },

        { new OreInfo(
            tile: GenVars.silverBar > 0 ? TileID.Silver : TileID.Tungsten, 
            amount: PlentifulOres.Config.Silver ) },

        { new OreInfo(
            tile: GenVars.ironBar > 0 ? TileID.Iron : TileID.Lead, 
            amount: PlentifulOres.Config.Iron) },

        { new OreInfo(
            tile: GenVars.goldBar > 0 ? TileID.Gold : TileID.Platinum, 
            amount: PlentifulOres.Config.Gold) },

        { new OreInfo(
            tile: WorldGen.crimson ? TileID.Crimtane : TileID.Demonite, 
            amount: PlentifulOres.Config.Crimtane) }
    };

    public override void ModifyWorldGenTasks(
        List<GenPass> tasks, 
        ref double totalWeight)
    {
        InsertGenerator(tasks, "Shinies", GenerateOres);
        InsertGenerator(tasks, "Gems", GenerateGems);
    }

    void InsertGenerator(
        List<GenPass> tasks, 
        string name, 
        WorldGenLegacyMethod method) 
    {
        int index = tasks.FindIndex(genpass => genpass.Name.Equals(name));
        if (index != -1)
            tasks.Insert(
                index: index + 1, 
                item: new PassLegacy(nameof(PlentifulOres), method));
    }

    void GenerateOres(
        GenerationProgress progress, 
        GameConfiguration configuration)
    {
        progress.Message = "Adding even more ores";

        foreach (var ore in ores)
            for (int n = 0; n < ore.Amount; n++)
                for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
                    GenerateTile(ore.Tile);
    }

    void GenerateGems(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding even more gems";

        List<OreInfo> gems = new()
        {
            { new OreInfo(TileID.Diamond, PlentifulOres.Config.Diamond) },
            { new OreInfo(TileID.Ruby, PlentifulOres.Config.Ruby) },
            { new OreInfo(TileID.Emerald, PlentifulOres.Config.Emerald) },
            { new OreInfo(TileID.Sapphire, PlentifulOres.Config.Sapphire) },
            { new OreInfo(TileID.Amethyst, PlentifulOres.Config.Amethyst) },
            { new OreInfo(TileID.Topaz, PlentifulOres.Config.Topaz) }
        };

        int tileCount = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);

        foreach (OreInfo gem in gems)
            for (int n = 0; n < gem.Amount; n++)
                for (int k = 0; k < tileCount; k++)
                    GenerateTile(gem.Tile);
    }

    void GenerateTile(ushort tileId) 
    {
        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
        int y = WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY);

        WorldGen.TileRunner(x, y, 
            strength: WorldGen.genRand.Next(3, 5), 
            steps: WorldGen.genRand.Next(3, 6), 
            type: tileId, 
            addTile: false, 
            speedX: 0f, 
            speedY: 0f, 
            noYChange: false, 
            overRide: true);
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
