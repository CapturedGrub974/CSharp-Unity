using UnityEngine;

[System.Serializable]
public struct LootItem
{
    public GameObject m_itemPrefab;
    public int m_maxDropAmount;
}

public class EnemyHealthManager : MonoBehaviour
{
    public int m_currentHealth;
    public int m_maxHealth;

    private bool m_flashActive;
    [SerializeField] private float m_flashLength;
    private float m_flashCounter;
    private SpriteRenderer m_enemySprite;

    public LootItem[] m_lootDrops;

    void Start()
    {
        m_enemySprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (m_flashActive)
        {
            if ((int)(100 * m_flashCounter / 16) % 2 == 0)
            { 
                m_enemySprite.color = new Color(1f, 1f, 1f, 1f); 
            }
            else
            { 
                m_enemySprite.color = new Color(1f, 1f, 1f, 0f); 
            }
            if (m_flashCounter <= 0)
            {
                m_enemySprite.color = new Color(1f, 1f, 1f, 1f);
                m_flashActive = false;
            }
            m_flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int m_damage)
    {
        m_currentHealth -= m_damage;
        m_flashActive = true;
        m_flashCounter = m_flashLength;

        if (m_currentHealth <= 0)
        {
            DropLoot();
            Destroy(gameObject);
        }
    }

    private void DropLoot()
    {
        foreach (LootItem loot in m_lootDrops)
        {
            if (loot.m_itemPrefab == null) continue;

            int dropCount = Random.Range(0, loot.m_maxDropAmount + 1);
            for (int i = 0; i < dropCount; i++)
            {
                Instantiate(loot.m_itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}