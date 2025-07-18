using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] ParticleSystem muzzleFlashParticle;

    StarterAssetsInputs starterAssetsInputs;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlashParticle.Play();

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(damage);
        }

        starterAssetsInputs.ShootInput(false);
    }
}
