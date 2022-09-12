using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "DATA/WEAPONE/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public string gunName;

    [Header("Shooting")]
    public float damage;
    public float maxDistance;
    public float fireDelay;
    public bool isAutomatic;

    [Header("Reloading")]
    public int startAmmo;
    public int currentAmmo;
    public int magSize;
    public float reloadTime;
    [HideInInspector]
    public bool isReloading;
}
