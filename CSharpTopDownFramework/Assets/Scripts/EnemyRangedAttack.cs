using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public GameObject m_enemyProjectile;
    public Transform m_projectilePos;
    [SerializeField]
    private float m_shootingRange;

    private float m_timer;
    private GameObject m_player;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, m_player.transform.position);

        if (distance < m_shootingRange)
        {
            m_timer += Time.deltaTime;

            if (m_timer > 2)
            {
                m_timer = 0;
                shoot();
            }
        }

    }

    void shoot()
    {
        Instantiate(m_enemyProjectile, m_projectilePos.position, Quaternion.identity);
    }
}
