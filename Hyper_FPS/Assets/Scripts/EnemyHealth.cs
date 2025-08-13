using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int maxHealth = 3;
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
