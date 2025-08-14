using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;

    int currentHealth;

    void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount) 
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
