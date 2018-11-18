using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace PlentifulOres
{
    class OrePopullator : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Example Mod Ores", PlentifulOres));
            }
            tasks.RemoveAll(x => x.Name.Equals("Beaches"));
        }

        private void PlentifulOres(GenerationProgress progress)
        {
            progress.Message = "Adding Even More Vanilla Ores";

            IronGeneration(20);
            GoldGeneration(20);
            GemGeneration(2);
        }

        private void IronGeneration(int amount) {
            for (int n = 0; n < amount; n++) {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                    WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), WorldGen.ironBar > 0 ? TileID.Iron : TileID.Lead, false, 0f, 0f, false, true);
                }
            }
               
        }

        private void GoldGeneration(int amount)
        {
            for (int n = 0; n < amount; n++)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                    WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), WorldGen.goldBar > 0 ? TileID.Gold : TileID.Platinum, false, 0f, 0f, false, true);
                }
            }
               
        }

        private void GemGeneration(int amount)
        {
            ushort[] gems = {TileID.Diamond, TileID.Ruby, TileID.Emerald, TileID.Sapphire, TileID.Topaz};

            for (int n = 0; n < amount; n++) {
                for (int i = 0; i < gems.Length; i++)
                {
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                        int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                        WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(3, 5), WorldGen.genRand.Next(3, 6), gems[i], false, 0f, 0f, false, true);
                    }
                }
            }
        }
    }
}
