using PathfindingDemo.Util.Physics;

namespace PathfindingDemo.Game.Pathfinding;

internal class Node
{
    public int H { get; init; }             //the estimated cost from this node to the end node
    public int G { get; set; }              //the cost from the start node to this node
    public Position Pos { get; init; }      //the position of this node
    public Node? ParentNode { get; set; }   //the node that came before this node
    public int F { get => G + H; }          //calculates the F-score
}
