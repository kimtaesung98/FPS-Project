using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public int Damage = 1;
    public float FireRate = .5f;
    public GameObject HitVFXPrefab;
}
