using UnityEngine;

public class FieldTile : MonoBehaviour
{
	private Crop currCrop;

	public GameObject cropPreFab;

	public SpriteRenderer sr;
	public bool tilled;

	[Header("Sprites")]
	public Sprite grassSprite;
	public Sprite tilledSprite;
	public Sprite wateredTilledSprite;

	public void Start()
	{
		sr.sprite = grassSprite;
	}

	public void Interact()
	{
		if (!tilled)
		{
			Till();
		}
		else if (!HasCrop() && GameManager.instance.CanPlantCrop())
		{
			PlantNewCrop(GameManager.instance.selectedCropToPlant);
		}
		else if (HasCrop() && currCrop.CanHarvest())
		{
			currCrop.Harvest();
		}
		else
		{
			Water();
		}
	}

	public void PlantNewCrop(CropData crop)
	{
		if (!tilled)
			return;
		currCrop = Instantiate(cropPreFab, transform).GetComponent<Crop>();
		currCrop.Plant(crop);

		GameManager.instance.onNewDay += OnNewDay;
	}
	void Till()
	{
		tilled = true;
		sr.sprite = tilledSprite;
	}
	void Water()
	{
		sr.sprite = wateredTilledSprite;
		if (HasCrop())
		{
			currCrop.Water();
		}
	}
	void OnNewDay()
	{
		if (currCrop == null)
		{
			tilled = false;
			sr.sprite = grassSprite;
			GameManager.instance.onNewDay -= OnNewDay;
		}
		else if (currCrop != null)
		{
			sr.sprite = tilledSprite;
			currCrop.NewDayCheck();
		}
	}

	bool HasCrop()
	{
		return currCrop != null;
	}
}