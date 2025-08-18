using Cinemachine;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;

    int currentHealth;
    int deathCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(amount + " damage taken");

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null; // WeaponCamera를 플레이어로부터 분리 -> 카메라가 사라지지 않도록 함
            deathVirtualCamera.Priority = deathCameraPriority; // 죽으면 DeathCamera의 우선순위를 높여서 보이도록 함
            Destroy(this.gameObject);
        }
    }
}
