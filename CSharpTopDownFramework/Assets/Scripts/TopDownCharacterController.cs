using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;

/// <summary>
/// A class to control the top down character.
/// Implements the player controls for moving and shooting.
/// Updates the player animator so the character animates based on input.
/// </summary>
public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    
    //The direction that the player is moving in.
    private Vector2 m_playerDirection;
   
    [SerializeField] private BoxCollider2D m_boxCollider;

    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;
    
    [Header("Dash")]
    public float m_dashSpeed;
    public float m_dashLength = .5f, m_dashCooldown = 1f;
    private float m_activeMoveSpeed;
    private float m_dashCounter;
    private float m_dashCooldownCounter;
    private bool m_isDashing;

    [Header("Lighting parameters")]
    [SerializeField] private Transform m_torchLight;

    private float m_attackTime = .25f;
    private float m_attackCounter = .25f;
    private bool m_isAttacking;

    #endregion

    /// <summary>
    /// When the script first initialises this gets called.
    /// Use this for grabbing components and setting up input bindings.
    /// </summary>
    private void Awake()
    {
        //bind movement inputs to variables
        m_moveAction = InputSystem.actions.FindAction("Move");
        
        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Called after Awake(), and is used to initialize variables e.g. set values on the player
    /// </summary>
    void Start()
    {
        m_activeMoveSpeed = m_playerSpeed;
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc performance.
    /// This ensures that physics are calculated properly.
    /// </summary>
    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_activeMoveSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_activeMoveSpeed;
        
        if (!m_isAttacking)
        {
            //apply the movement to the character using the clamped speed value.
            m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
        }
        else
        {
            
        }
    }
    
    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
    void Update()
    {
        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();
        
        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_playerDirection.magnitude);
        
        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        if (m_playerDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_playerDirection.x);
            m_animator.SetFloat("Vertical", m_playerDirection.y);

            //float angle = Mathf.Atan2(m_torchDirection.y, m_torchDirection.x) * Mathf.Rad2Deg;
            //m_torchLight.rotation = Quaternion.Euler(0, 0, angle - 90);
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
                    m_boxCollider.enabled = false;
                }
            }

            if (m_dashCounter > 0)
            {
                m_dashCounter -= Time.deltaTime;

                if (m_dashCounter <= 0)
                {
                    m_activeMoveSpeed = m_playerSpeed;
                    m_dashCooldownCounter = m_dashCooldown;
                    m_boxCollider.enabled = true;
                }
            }

            if (m_dashCooldownCounter > 0)
            {
                m_dashCooldownCounter -= Time.deltaTime;
            }
        }
    } 
}
