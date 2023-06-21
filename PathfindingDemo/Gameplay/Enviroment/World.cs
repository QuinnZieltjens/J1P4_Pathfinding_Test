using PathfindingDemo.Gameplay.Entities;
using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Gameplay.Enviroment;


internal class World
{
    private readonly List<Entity> entities;
    private bool[,]? tiles;
    private int? sizeX;
    private int? sizeY;

    public bool[,] Tiles
    {
        init => tiles = value;
        private get => tiles ?? throw new NullReferenceException();
    }

    public int SizeX
    {
        init => sizeX = value;
        get => sizeX ?? throw new NullReferenceException();
    }

    public int SizeY
    {
        init => sizeY = value;
        get => sizeY ?? throw new NullReferenceException();
    }

    public IReadOnlyCollection<Entity> Entities
    {
        init => entities = value.ToList();
        get => entities;
    }

    public World()
    {
        entities = new List<Entity>();
    }

    public void AddEntity(Entity _entity)
    {
        entities.Add(_entity);
    }

    public bool IsWall(Position _position)
    {
        if (_position.X < 0 || _position.X >= sizeX)
            return true;

        if (_position.Y < 0 || _position.Y >= sizeY)
            return true;

        return Tiles[_position.X, _position.Y];
    }
}
