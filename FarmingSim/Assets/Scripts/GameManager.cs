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

	void OnEnable()
	{
		Crop.onCropPlant += OnPlantCrop;
		Crop.onHarvestCrop += OnHarvestCrop;
	}

	void OnDisable()
	{
		Crop.onCropPlant -= OnPlantCrop;
		Crop.onHarvestCrop -= OnHarvestCrop;

	}
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
		cropInInventory--;
	}

	public void OnHarvestCrop(CropData crop)
	{
		money += crop.salePrice;
	}
	public void PurchaseCrop(CropData crop)
	{

	}
	public bool CanPlantCrop()
	{

		return cropInInventory > 0;
	}

	public void OnBuyCrop(CropData crop)
	{

	}
	void UpdateStatsText()
	{

	}
}