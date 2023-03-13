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
	private TGridObject[,] gridArray;
	private Vector3 originPosition;


	public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createdGridObject)
	{
		this.width = width;
		this.heigth = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;
		this.cellSize = cellSize;

		gridArray = new TGridObject[width, height];

		for (int x = 0; x < gridArray.GetLength(0); x++)
		{
			for (int y = 0; y < gridArray.GetLength(1); y++)
			{
				gridArray[x, y] = createdGridObject(this, x, y);
			}
		}
		bool showDebug = true;

		if (showDebug)
		{
			TextMesh[,] debugTextArray = new TextMesh[width, height];
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
	}

	private Vector3 GetWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * cellSize + originPosition;
	}
	public void GetXY(Vector3 worldPosition, out int x, out int y)
	{
		x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
		y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
	}
	public void SetGridObject(int x, int y, TGridObject value)
	{
		if (x >= 0 && y >= 0 && x < width && y < heigth)
		{
			gridArray[x, y] = value;
			if (OnGridObjectChange != null) OnGridObjectChange(this, new OnGridObjectChangeEventArgs { x = x, y = y });
		}
	}
	public void TriggerGridObjectChanged(int x, int y)
	{
		if (OnGridObjectChange != null) OnGridObjectChange(this, new OnGridObjectChangeEventArgs { x = x, y = y });
	}
	public void SetGridObject(Vector3 worldPosition, TGridObject value)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);
		SetGridObject(x, y, value);
	}

	public TGridObject GetGridObject(int x, int y)
	{
		if (x >= 0 && y >= 0 && x < width && y < heigth)
		{
			return gridArray[x, y];
		}
		else
		{
			return default(TGridObject);
		}
	}

	public TGridObject GetGridObject(Vector3 worldPosition)
	{
		int x, y;
		GetXY(worldPosition, out x, out y);

		return GetGridObject(x, y);
	}
	public int GetHeight()
	{
		return heigth;
	}
	public int GetWidth()
	{
		return width;
	}



}
