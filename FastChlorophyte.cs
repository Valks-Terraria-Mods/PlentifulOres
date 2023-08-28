namespace PlentifulOres;

public class FastChlorophyte : GlobalTile
{
    public override void RandomUpdate(int i, int j, int type)
    {
        FastChlorophyteOre(i, j, type);
    }

    void FastChlorophyteOre(int i, int j, int type)
    {
        if (type != TileID.Chlorophyte || !PlentifulOres.Config.FastChlorophyte)
            return;

        Spread(i, j, 1, 0);
        Spread(i, j, -1, 0);
        Spread(i, j, 0, 1);
        Spread(i, j, 0, -1);
        Spread(i, j, 1, 1);
        Spread(i, j, -1, -1);
        Spread(i, j, 1, -1);
        Spread(i, j, -1, 1);
    }

    void Spread(int i, int j, int offsetX, int offsetY)
    {
        int x = i + offsetX;
        int y = j + offsetY;

        Tile tile = Main.tile[x, y];

        if (tile.HasTile && tile.TileType == TileID.Mud)
        {
            WorldGen.KillTile(x, y, noItem: true);
            WorldGen.PlaceTile(x, y, TileID.Chlorophyte, mute: true, forced: true);
        }
    }
}
