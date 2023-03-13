using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
	private const int MOVE_STRAIGHT_COST = 10;
	private const int MOVE_DIAGONAL_COST = 14;
	private Grid<PathNode> grid;
	private List<PathNode> openList;
	private List<PathNode> closedList;
	public Pathfinding(int width, int heith)
	{
		grid = new Grid<PathNode>(width, heith, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));

	}

	private List<PathNode> FindPath(int startX, int startY, int endX, int endY)
	{
		PathNode startNode = grid.GetGridObject(startX, startY);
		PathNode endNode = grid.GetGridObject(endX, endY);

		openList = new List<PathNode> { startNode };
		closedList = new List<PathNode>();

		for (int x = 0; x < grid.GetWidth(); x++)
		{
			for (int y = 0; y < grid.GetHeight(); y++)
			{
				PathNode pathNode = grid.GetGridObject(x, y);
				pathNode.gCost = int.MaxValue;
				pathNode.CalculateFCost();
				pathNode.cameFromNode = null;
			}

		}
		startNode.gCost = 0;
		startNode.hCost = CalculateDistabce(startNode, endNode);
		startNode.CalculateFCost();

	}

	private int CalculateDistabce(PathNode a, PathNode b)
	{
		int xDistance = Mathf.Abs(a.x - b.x);
		int yDistance = Mathf.Abs(a.y - b.y);
		int remaining = Mathf.Abs(xDistance - yDistance);
		return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
	}
}
