using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	private Vector2 moveInput;
	private bool interactInput;
	private Vector2 facingDir;
	public LayerMask interactLayerMask;
	public Rigidbody2D rig;
	public SpriteRenderer sr;

	// Called every 0.02 seconds.
	void FixedUpdate()
	{
		// Move the player based on the input and move speed.
		rig.velocity = moveInput.normalized * moveSpeed;
	}
	// Called when we press a movement key.
	public void OnMoveInput(InputAction.CallbackContext context)
	{
		moveInput = context.ReadValue<Vector2>();
	}

	// Called when we press the interact key.
	public void OnInteractInput(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
		{
			interactInput = true;
		}
	}
}