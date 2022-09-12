using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	public UnityEvent<Vector3> OnMoveButtonPress;
	public UnityEvent<Vector3> OnCameraMove;
	public UnityEvent OnFireButtonPress;
	public UnityEvent OnReloadButtonPress;

	[SerializeField] private KeyCode useWeapone;
	[SerializeField] private KeyCode reloadGun;

	private Movement movement;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		movement = GetComponent<Movement>();
	}

	private void Update()
	{
		Movement();
		CamMove();
		Weapone();
	}

	private void Movement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");

		OnMoveButtonPress?.Invoke(new Vector3(x, z));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			movement.JumpTo();
		}
	}

	private void CamMove()
	{
		float yRotSize = Input.GetAxis("Mouse X");
		float xRotSize = -Input.GetAxis("Mouse Y");

		OnCameraMove?.Invoke(new Vector3(xRotSize, yRotSize, 0));
	}

	private void Weapone()
	{
		if (Input.GetKeyDown(useWeapone))
		{
			OnFireButtonPress?.Invoke();
		}
		if (Input.GetKeyDown(reloadGun))
		{
			OnReloadButtonPress?.Invoke();
		}
	}
}
