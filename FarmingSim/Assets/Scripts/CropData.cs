using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "New Crop Data")]
public class CropData : ScriptableObject
{
	public int daysToGrow;
	public Sprite[] growProgressSprites;
	public Sprite readyToHarvestSprite;

	public int purchasePrice;
	public int salePrice;


}
