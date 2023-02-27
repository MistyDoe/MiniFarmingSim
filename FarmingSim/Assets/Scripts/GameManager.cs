using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	public int curDay;
	public int money;
	public int cropInInventory;

	public CropData selectedCropToPlant;
	public TextMeshProUGUI statsText;

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
		curDay++;
		onNewDay?.Invoke();
		UpdateStatsText();
	}

	public void OnPlantCrop(CropData crop)
	{
		cropInInventory--;
		UpdateStatsText();
	}

	public void OnHarvestCrop(CropData crop)
	{
		money += crop.salePrice;
		UpdateStatsText();
	}
	public void PurchaseCrop(CropData crop)
	{
		UpdateStatsText();
		money -= crop.salePrice;
		cropInInventory++;
		UpdateStatsText();

	}
	public bool CanPlantCrop()
	{
		return cropInInventory > 0;
	}

	public void OnBuyCrop(CropData crop)
	{
		if (money >= crop.salePrice)
		{
			PurchaseCrop(crop);
		}
	}
	void UpdateStatsText()
	{
		statsText.text = $"Day {curDay}\nMoney ${money}\nSeeds : {cropInInventory}";
	}
}