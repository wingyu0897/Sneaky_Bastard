using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
	[SerializeField] private float health = 100.0f;

	public void Damage(float damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
