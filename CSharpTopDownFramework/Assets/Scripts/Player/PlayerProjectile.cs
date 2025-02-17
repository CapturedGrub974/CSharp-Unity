using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Vector3 m_mousePos;
    private Camera m_mainCam;
    private Rigidbody2D m_rigidbody;
    public float m_force;
    private float m_timer;
    public int m_damage;
    // Start is called before the first frame update
    void Start()
    {
        m_mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_mousePos = m_mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = m_mousePos - transform.position;
        Vector3 rotation = transform.position - m_mousePos;
        m_rigidbody.linearVelocity = new Vector2(direction.x, direction.y).normalized * m_force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
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
        if (other.tag == "Enemy")
        {
            EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthMan.HurtEnemy(m_damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
