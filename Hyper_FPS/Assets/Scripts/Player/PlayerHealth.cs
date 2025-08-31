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
    [SerializeField] GameObject gameOverContainer;

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
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        weaponCamera.parent = null; // WeaponCamera를 플레이어로부터 분리 -> 카메라가 사라지지 않도록 함
        deathVirtualCamera.Priority = deathCameraPriority; // DeathCamera의 우선순위를 높여서 보이도록 함
        gameOverContainer.SetActive(true); // 죽으면 게임오버 화면을 보여줌
        Destroy(gameObject);
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
