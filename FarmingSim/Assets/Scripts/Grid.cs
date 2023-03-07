using UnityEngine;

public class Grid : MonoBehaviour
{
	public int width;
	public int heigth;
	private float cellSize;
	private int[,] gridArray;


	public Grid(int width, int height, float cellSize)
	{
		this.width = width;
		this.heigth = height;
		this.cellSize = cellSize;

		gridArray = new int[width, height];

		Debug.Log(width + " " + height);
		this.cellSize = cellSize;

		for (int x = 0; x < gridArray.GetLength(0); x++)
		{
			for (int y = 0; y < gridArray.GetLength(1); y++)
			{
				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 100f);
				Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.red, 100f);
			}

			Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.red, 100f);
			Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, 100f);
		}
	}

	private Vector3 GetWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * cellSize;
	}

}
