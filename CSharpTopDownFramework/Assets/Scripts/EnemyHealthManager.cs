using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    [SerializeField] GameObject m_coinPrefab;

    void Update()
    {
        
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            for (Random.Range(1, 5);
            {
                GameObject coinToSpawn = Instantiate(m_coinPrefab, transform.position, Quaternion.identity);
            }
            
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
