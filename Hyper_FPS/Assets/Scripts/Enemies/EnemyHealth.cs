using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    GameManager gameManager;

    void Awake() 
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustenemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            gameManager.AdjustenemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
