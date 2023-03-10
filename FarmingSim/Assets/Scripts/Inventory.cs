using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<InventoryItem> items;


	public void AddItem(InventoryItem item)
	{
		if (items.FirstOrDefault(f => f.name == item.name))
		{
			item.Quantity++;
		}
		items.Add(item);

	}

	public void RemoveItem(InventoryItem item)
	{
		item.Quantity--;
		if (item.Quantity <= 0)
		{
			items.Remove(item);
		}
	}
}
