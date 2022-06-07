namespace PlentifulOres;

public class OrePopulator : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
    {
        InsertGenerator(tasks, "Shinies", GenerateOres);
        InsertGenerator(tasks, "Gems", GenerateGems);
    }

    private static void InsertGenerator(List<GenPass> tasks, string name, WorldGenLegacyMethod method) 
    {
        var index = tasks.FindIndex(genpass => genpass.Name.Equals(name));
        if (index != -1)
            tasks.Insert(index + 1, new PassLegacy(nameof(PlentifulOres), method));
    }

    private static void GenerateOres(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding even more ores";

        var ores = new List<OreInfo>
        {
            { new OreInfo(WorldGen.copperBar > 0 ? TileID.Copper : TileID.Tin, PlentifulOres.Config.Copper) },
            { new OreInfo(WorldGen.silverBar > 0 ? TileID.Silver : TileID.Tungsten, PlentifulOres.Config.Silver ) },
            { new OreInfo(WorldGen.ironBar > 0 ? TileID.Iron : TileID.Lead, PlentifulOres.Config.Iron) },
            { new OreInfo(WorldGen.goldBar > 0 ? TileID.Gold : TileID.Platinum, PlentifulOres.Config.Gold) },
            { new OreInfo(WorldGen.crimson ? TileID.Crimtane : TileID.Demonite, PlentifulOres.Config.Crimtane) }
        };

        foreach (var ore in ores)
            for (int n = 0; n < ore.Amount; n++)
                for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
                    GenerateTile(ore.Tile);
    }

    private static void GenerateGems(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding even more gems";
        
        var gems = new List<OreInfo>
        {
            { new OreInfo(TileID.Diamond, PlentifulOres.Config.Diamond) },
            { new OreInfo(TileID.Ruby, PlentifulOres.Config.Ruby) },
            { new OreInfo(TileID.Emerald, PlentifulOres.Config.Emerald) },
            { new OreInfo(TileID.Sapphire, PlentifulOres.Config.Sapphire) },
            { new OreInfo(TileID.Topaz, PlentifulOres.Config.Topaz) }
        };

        foreach (var gem in gems)
            for (int n = 0; n < gem.Amount; n++)
                for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
                    GenerateTile(gem.Tile);
    }

    private static void GenerateTile(ushort tile) 
    {
        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
        int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);

        WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(3, 6), tile, false, 0f, 0f, false, true);
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