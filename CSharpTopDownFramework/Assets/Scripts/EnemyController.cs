using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator m_animator;
    private Transform m_target;
    public Transform m_homePos;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_range;
    [SerializeField] private float m_maxRange;
    [SerializeField] private float m_minRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_target = FindObjectOfType<TopDownCharacterController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_target.position, transform.position) <= m_maxRange && Vector3.Distance(m_target.position, transform.position) >= m_minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(m_target.position, transform.position) >= m_maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        m_animator.SetBool("IsMoving", true);
        m_animator.SetFloat("Horizontal", (m_target.position.x - transform.position.x));
        m_animator.SetFloat("Vertical", (m_target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);
    }

    public void GoHome()
    {
        m_animator.SetFloat("Horizontal", (m_homePos.position.x - transform.position.x));
        m_animator.SetFloat("Vertical", (m_homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, m_homePos.position, m_speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, m_homePos.position) == 0)
        {
            m_animator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
