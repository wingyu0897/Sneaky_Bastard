using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
	[SerializeField] private Transform camTransform;

	private void LateUpdate()
	{
		transform.localRotation = Quaternion.Euler(new Vector3(camTransform.eulerAngles.x, 0));
	}
}
