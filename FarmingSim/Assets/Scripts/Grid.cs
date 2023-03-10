using System;
using UnityEngine;

public class Grid<TGridObject>
{
	public event EventHandler<OnGridObjectChangeEventArgs> OnGridObjectChange;
	public class OnGridObjectChangeEventArgs : EventArgs
	{
		public int x;
		public int y;
	}

	public int width;
	public int heigth;
	private float cellSize;
	private int[,] gridArray;
	private Vector3 originPosition;


	public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>>, int , int, TGridObject createdGridObject)
	{
		this.width = width;
		this.heigth = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;

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
		return new Vector3(x, y) * cellSize + originPosition;
	}
	public void Setvalue(int x, int y, int value)
	{
		if (x >= 0 && y >= 0 && x < width && y < heigth)
		{
			gridArray[x, y] = value;
			if (OnGridObjectChange != null) OnGridObjectChange(this, new OnGridObjectChangeEventArgs { x = x, y = y });

		}
	}

}
