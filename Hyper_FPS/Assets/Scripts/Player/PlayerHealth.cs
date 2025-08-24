using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;

    int currentHealth;
    int deathCameraPriority = 20;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustShieldUI();
        
        if (currentHealth <= 0)
        {
            weaponCamera.parent = null; // WeaponCamera를 플레이어로부터 분리 -> 카메라가 사라지지 않도록 함
            deathVirtualCamera.Priority = deathCameraPriority; // 죽으면 DeathCamera의 우선순위를 높여서 보이도록 함
            Destroy(this.gameObject);
        }
    }

    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth) 
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else 
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}
