using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public int curDay;
	public int money;
	public int cropInInventory;

	public CropData selectedCropToPlant;

	public static GameManager instance;

	public event UnityAction onNewDay;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public void SetNextDay()
	{

	}

	public void OnPlantCrop(CropData crop)
	{

	}

	public void OnHarvestCrop(CropData crop)
	{

	}
	public void PurchaseCrop(CropData crop)
	{

	}
	public bool CanPlantCrop()
	{
		return true;
	}

	public void OnBuyCrop(CropData crop)
	{

	}
	void UpdateStatsText()
	{

	}
}