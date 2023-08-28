using System;

namespace PlentifulOres;

public class SpawnLunarOre : GlobalNPC
{
    public override void OnKill(NPC npc)
    {
        if (npc.type != NPCID.MoonLordCore ||
            !PlentifulOres.Config.KillingMoonLordSpawnsLuminiteOre)
            return;

        Main.NewText("Your world has been blessed with luminite ore",
            R: 255,
            G: 0,
            B: 255);

        for (int i = 0; i < 10000; i++)
        {
            int x = new Random().Next(0, Main.maxTilesX);
            int y = new Random().Next(
                minValue: (int)GenVars.rockLayerLow,
                maxValue: Main.maxTilesY);

            Tile tile = Main.tile[x, y];

            if (tile.HasTile && TileID.Sets.Ore[tile.TileType])
                tile.ResetToType(TileID.LunarOre);
        }
    }
}
