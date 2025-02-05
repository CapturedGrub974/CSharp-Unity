using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private HealthManager m_healthMan;
    private float m_attackTimeout = 1f;
    private bool m_isTouching;
    [SerializeField] private int m_damage;
    // Start is called before the first frame update
    void Start()
    {
        m_healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isTouching)
        {
            m_attackTimeout -= Time.deltaTime;
            if (m_attackTimeout <= 0)
            {
                m_healthMan.HurtPlayer(m_damage);
                m_attackTimeout = 1f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(m_damage);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            m_isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            m_isTouching = false;
            m_attackTimeout = 1f;
        }
    }
}
