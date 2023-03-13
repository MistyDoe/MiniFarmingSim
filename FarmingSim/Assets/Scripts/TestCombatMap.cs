using System.Collections.Generic;
using UnityEngine;

public class TestCombatMap : MonoBehaviour
{
	private Pathfinding pathfinding;
	void Start()
	{
		Pathfinding pathfinding = new Pathfinding(10, 10);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseWorldPosition = GameManager.GetMouseWorldPosition();
			pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
			List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
		}
	}

}
