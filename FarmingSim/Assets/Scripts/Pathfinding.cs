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

		while (openList.Count > 0)
		{
			PathNode currentNode = GetLowestFCostNode(openList);


		}
	}
	private List<PathNode> GetNeighboursList(PathNode currentNode)
	{
		List<PathNode> neighbourList = new List<PathNode>();

		if (currentNode.x - 1 >= 0)
		{
			//left Node
			neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
			//left down node
			if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
			// left up node
			if (currentNode.y + 1 < grid.GetWidth()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
		}
		if (currentNode.y >= grid.GetWidth())
		{
			//right node
			neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));
			//right down node
			if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
			//right up node 
			if (currentNode.y + 1 <= grid.GetWidth()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
		}
		//down node
		if (currentNode.y + 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));

		//up node
		if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

		return neighbourList;
	}
	public PathNode GetNode(int x, int y)
	{
		return grid.GetGridObject(x, y);
	}
	private List<PathNode> CalculatePaht(PathNode endNode)
	{
		return null;
	}
	private int CalculateDistabce(PathNode a, PathNode b)
	{
		int xDistance = Mathf.Abs(a.x - b.x);
		int yDistance = Mathf.Abs(a.y - b.y);
		int remaining = Mathf.Abs(xDistance - yDistance);
		return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
	}

	private PathNode GetLowestFCostNode(List<PathNode> pathNodesList)
	{
		PathNode lowestFCostNode = pathNodesList[0];

		for (int i = 1; i < pathNodesList.Count; i++)
		{
			if (pathNodesList[i].fCost < lowestFCostNode.fCost)
			{
				lowestFCostNode = pathNodesList[i];
			}
		}
		return lowestFCostNode;
	}
}
