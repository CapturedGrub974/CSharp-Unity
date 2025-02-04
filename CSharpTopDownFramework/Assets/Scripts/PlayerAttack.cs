using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject m_projectilePrefab;
    [SerializeField] Transform m_firePoint;
    [SerializeField] float m_projectileSpeed;
    [SerializeField] float m_fireRate;
    private float m_fireTimeout = 0;
    private Vector2 m_lastDirection;
    private Vector3 mousePos;
    private InputAction m_attackAction;
    private bool m_bowEquipped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        m_attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time > m_fireTimeout)
        {
            m_fireTimeout = Time.time + m_fireRate;
            Fire(); 
        }
    }


    private void Fire()
    {
        Vector3 mousePointOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 fireDirection = (mousePointOnScreen - m_firePoint.position).normalized;

        GameObject projectileToSpawn = Instantiate(m_projectilePrefab, m_firePoint.position, Quaternion.identity);

        if (projectileToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            projectileToSpawn.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }

        float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        projectileToSpawn.transform.rotation = Quaternion.Euler(0, 0, angle + 270);
    }
}
