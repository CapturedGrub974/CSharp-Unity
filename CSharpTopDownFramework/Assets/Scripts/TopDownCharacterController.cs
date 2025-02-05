using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;
    
public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables
    public CircleCollider2D m_circleCollider;
    public Rigidbody2D m_rigidbody;
    public Animator m_animator;
    private float m_activeMoveSpeed;

    [Header("Movement")]
    [SerializeField] private float m_moveSpeed;
    private float m_attackTime = .25f;
    private float m_attackCounter = .25f;
    private bool m_isAttacking;
    Vector2 m_movement;

    public float m_dashSpeed;
    public float m_dashLength = .5f, m_dashCooldown = 1f;
    private float m_dashCounter;
    private float m_dashCooldownCounter;
    private bool m_isDashing;

    [Header("Projectile")]
    public GameObject m_arrowPrefab;

    [Header("Lighting parameters")]
    [SerializeField] private Transform m_torchLight;
    


    #endregion

    void Start()
    {
        m_activeMoveSpeed = m_moveSpeed;
    }

    void Update()
    {
        if (!m_isAttacking)
        {
            m_movement.x = Input.GetAxisRaw("Horizontal");
            m_movement.y = Input.GetAxisRaw("Vertical");
            m_movement = m_movement.normalized;
            m_rigidbody.linearVelocity = m_movement * m_activeMoveSpeed;
        }
        else
        {
            // Set movement to zero while attacking to freeze the player
            m_movement = Vector2.zero;
            m_rigidbody.linearVelocity = Vector2.zero;
        }

        m_animator.SetFloat("Horizontal", m_movement.x);
        m_animator.SetFloat("Vertical", m_movement.y);
        m_animator.SetFloat("Speed", m_movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            m_animator.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            m_animator.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            m_animator.SetBool("Animator", true);
        }

        else
        {
            m_animator.SetBool("Animator", false);
        }

        if (!m_isDashing)
        {
            if (m_isAttacking)
            {
                m_attackCounter -= Time.deltaTime;
                if (m_attackCounter <= 0)
                {
                    m_animator.SetBool("IsAttacking", false);
                    m_isAttacking = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_attackCounter = m_attackTime;
                m_animator.SetBool("IsAttacking", true);
                m_isAttacking = true;
            }
        }

        if (!m_isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_dashCooldownCounter <= 0 && m_dashCounter <= 0)
                {
                    m_activeMoveSpeed = m_dashSpeed;
                    m_dashCounter = m_dashLength;
                    m_animator.SetBool("IsDashing", true);
                    //m_circleCollider.enabled = false;
                    m_isDashing = true;
                }
            }

            if (m_dashCounter > 0)
            {
                m_dashCounter -= Time.deltaTime;

                if (m_dashCounter <= 0)
                {
                    m_activeMoveSpeed = m_moveSpeed;
                    m_dashCooldownCounter = m_dashCooldown;
                    m_animator.SetBool("IsDashing", false);
                    //m_circleCollider.enabled = true;
                    m_isDashing = false;
                }
            }

            if (m_dashCooldownCounter > 0)
            {
                m_dashCooldownCounter -= Time.deltaTime;
            }
        }
    } 
}
