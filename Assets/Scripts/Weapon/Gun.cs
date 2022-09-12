using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData data;
	public GunData Data { get => data; }
	[SerializeField] private Transform muzzle;
	[SerializeField] private ParticleSystem muzzleFlash;

	private float timeDelay = 0.0f;

	private void Awake()
	{
		data.currentAmmo = data.magSize;
		data.isReloading = false;
	}

	private void Update()
	{
		timeDelay += Time.deltaTime;
	}

	private bool CanShoot()
	{
		return !data.isReloading && timeDelay > data.fireDelay;
	}

	public void Shoot()
	{
		if (data.currentAmmo > 0)
		{
			if (CanShoot())
			{
				if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hit, data.maxDistance))
				{
					IDamageable damageObj = hit.transform.GetComponent<IDamageable>();
					damageObj?.Damage(data.damage);
					Debug.Log(hit.transform.name);
				}

				muzzleFlash?.Play();
				data.currentAmmo--;
				timeDelay = 0.0f;
			}
		}
	}

	public void Reload()
	{
		if (!data.isReloading)
		{
			StartCoroutine(Reloading());
		}
	}

	IEnumerator Reloading()
	{
		data.isReloading = true;

		yield return new WaitForSeconds(data.reloadTime);

		data.currentAmmo = data.magSize;

		data.isReloading = false;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(muzzle.position, muzzle.forward * 1000);
	}
}
