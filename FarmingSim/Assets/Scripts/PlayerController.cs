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

	private void Update()
	{
		if (moveInput.magnitude != 0.0f)
		{
			facingDir = moveInput.normalized;
			sr.flipX = moveInput.x > 0;
		}
	}

	void FixedUpdate()
	{

		rig.velocity = moveInput.normalized * moveSpeed;
	}

	public void OnMoveInput(InputAction.CallbackContext context)
	{
		moveInput = context.ReadValue<Vector2>();
	}


	public void OnInteractInput(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
		{
			interactInput = true;
		}
	}
}