using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public int m_damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager m_eHealthMan;
            m_eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            m_eHealthMan.HurtEnemy(m_damage);
        }
    }
}
