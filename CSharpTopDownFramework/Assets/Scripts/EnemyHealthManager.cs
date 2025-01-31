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

            int randomIterations = Random.Range(1, 6); // Range is inclusive of min and exclusive of max

            for (int i = 0; i < randomIterations; i++)
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
