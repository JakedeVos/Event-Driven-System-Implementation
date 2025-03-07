using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { fire, Ice, Normal}
[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]

public class WeaponSO : ScriptableObject
{

    public float minDamage = 1;
    public float maxDamage = 10;
    public DamageType damageType = DamageType.fire;
}

