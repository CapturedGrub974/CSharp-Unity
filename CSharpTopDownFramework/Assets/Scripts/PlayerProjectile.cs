using System.Threading;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private int m_damage;
    private float m_timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(m_damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall") || m_timer > 5)
        {
            Destroy(gameObject);
        }
    }
}
