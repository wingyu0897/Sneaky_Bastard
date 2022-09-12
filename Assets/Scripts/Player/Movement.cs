using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController characterController;

	[SerializeField] 
	private Transform cam;
	[SerializeField] 
	private float moveSpeed = 5.0f;
	[SerializeField] 
	private float jumpForce = 3.0f;
	[SerializeField][Range(0.1f, 50.0f)] 
	private float mouseSensitivity = 5.0f;

	private float gravityScale = -9.8f;
	private float velocityY = 0.0f;
	private float xCamRot = 0.0f;
	private Vector2 currentDir;
	private Vector2 currentVelociity = Vector3.zero;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if (characterController.isGrounded == false)
		{
			velocityY += gravityScale * Time.deltaTime;
		}
	}

	public void MoveTo(Vector3 direction)
	{
		Vector2 targetDir = direction.normalized;
		currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentVelociity, 0.3f);

		Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * moveSpeed + Vector3.up * velocityY;
		characterController.Move(velocity * Time.deltaTime);
	}

	public void JumpTo()
	{
		if (characterController.isGrounded == true)
		{
			velocityY = jumpForce;
		}
	}

	public void FaceDirection(Vector3 direction)
	{
		float yCamRot = transform.eulerAngles.y + direction.y * mouseSensitivity;
		xCamRot = Mathf.Clamp(xCamRot + direction.x * mouseSensitivity, -80, 80); //나중에 변경

		transform.eulerAngles = new Vector3(0, yCamRot, 0);
		cam.localEulerAngles = new Vector3(xCamRot, 0, 0);
	}
}
