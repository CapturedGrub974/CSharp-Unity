using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
