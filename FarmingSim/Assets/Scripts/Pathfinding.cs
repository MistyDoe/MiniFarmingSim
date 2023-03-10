using UnityEngine;

public class Pathfinding
{
	private Grid<PathNode> grid;
	public Pathfinding(int width, int heith)
	{
		grid = new Grid<PathNode>(width, heith, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));

	}
}
