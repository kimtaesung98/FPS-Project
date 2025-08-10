using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponPrefab;
    public GameObject HitVFXPrefab;
    public int Damage = 1;
    public float FireRate = .5f;
    public bool IsAutomatic = false;
    public bool CanZoom = false;
    public float ZoomAmount = 10;
    public float ZoomRotationSpeed = 0.3f;
}
