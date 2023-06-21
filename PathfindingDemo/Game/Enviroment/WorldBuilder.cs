namespace PathfindingDemo.Game.Enviroment;

internal class WorldBuilder
{
    public string[]? WorldTileData { init; private get; }

    public World Build()
    {
        if (WorldTileData == null)
            throw new NullReferenceException("the world wasn't set");

        int sizeY = WorldTileData.Length;
        int sizeX = WorldTileData[0].Length;
        bool[,] tiles = new bool[sizeX, sizeY];

        for (int x = 0; x < WorldTileData.Length; x++)
        {
            for (int y = 0; y < WorldTileData[x].Length; y++)
            {
                tiles[y, x] = WorldTileData[x][y] switch
                {
                    ' ' => false,
                    'x' => true,
                    _ => throw new Exception(),
                };
            }
        }

        return new World()
        {
            Tiles = tiles,
            SizeX = sizeX,
            SizeY = sizeY,
        };
    }
}
