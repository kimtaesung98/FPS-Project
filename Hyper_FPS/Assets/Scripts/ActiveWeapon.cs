using UnityEngine;
using StarterAssets;
using Cinemachine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] CinemachineVirtualCamera followCamera;

    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Animator animator;
    Weapon currentWeapon;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot = 0f;
    float defaultFOV;
    float defaultRotationSpeed;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();

        defaultFOV = followCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }

    void HandleShoot()
    {
        timeSinceLastShot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }
        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }

    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            followCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotationSpeed);
        }
        else
        {
            followCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
