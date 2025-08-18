using UnityEngine;
public class AmmoPickup : Pickup
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int ammoAmount = 100;

    // Update is called once per frame
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        
        activeWeapon.AdjustAmmo(ammoAmount);
    }
}
