using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject m_player;
    private Rigidbody2D m_rigidbody;
    public float m_force;
    private float m_timer;
    [SerializeField]
    private int damageToGive = 10;
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = m_player.transform.position - transform.position;
        m_rigidbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * m_force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer > 5)
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        }
    }
}
