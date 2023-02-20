using UnityEngine;

public class FieldTile : MonoBehaviour
{
	//private Crop currCrop;

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
		Debug.Log("Interacted!");
	}
}