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
	public Sprite coin;
	public Inventory inventory;
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
	public void SetSelectedCrop(CropData selectedCrop)
	{
		selectedCropToPlant = selectedCrop;
		Debug.Log(selectedCropToPlant.Name);
	}
	public void SetNextDay()
	{
		curDay++;
		onNewDay?.Invoke();
		UpdateStatsText(selectedCropToPlant);
	}

	public void OnPlantCrop(CropData crop)
	{
		--selectedCropToPlant.quantityInInventory;
		UpdateStatsText(selectedCropToPlant);
	}

	public void OnHarvestCrop(CropData crop)
	{
		money += selectedCropToPlant.salePrice;
		UpdateStatsText(selectedCropToPlant);
	}
	public void PurchaseCrop(CropData selectedCropToPlant)
	{
		money -= selectedCropToPlant.purchasePrice;
		selectedCropToPlant.quantityInInventory++;
		UpdateStatsText(selectedCropToPlant);

	}
	public bool CanPlantCrop()
	{
		Debug.Log(selectedCropToPlant.quantityInInventory);
		return selectedCropToPlant.quantityInInventory > 0;
	}

	public void OnBuyCrop(CropData crop)
	{
		if (money >= selectedCropToPlant.purchasePrice)
		{
			PurchaseCrop(crop);
		}
	}
	void UpdateStatsText(CropData selectedCropToPlant)
	{

		statsText.text = $"Day {curDay}\n <sprite index=coin> : {money}\nSeeds :\n {selectedCropToPlant.cropName} {selectedCropToPlant.quantityInInventory}";
	}
}