using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "New Crop Data")]
public class CropData : InventoryItem
{
	public int daysToGrow;
	public Sprite[] growProgressSprites;
	public Sprite readyToHarvestSprite;
	public string cropName;
	public string itemType;
	public int quantityInInventory;

	public int purchasePrice;
	public int salePrice;




}
