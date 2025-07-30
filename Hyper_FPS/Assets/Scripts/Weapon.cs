using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject hitVPXPrefab;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] ParticleSystem muzzleFlashParticle;
    [SerializeField] Animator animator;
        const string SHOOT_ANIM = "Shoot";

    StarterAssetsInputs starterAssetsInputs;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzleFlashParticle.Play();
        animator.Play(SHOOT_ANIM, 0, 0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVPXPrefab, hit.point, Quaternion.identity);
            hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(weaponSO.Damage);
        }
    }
}
