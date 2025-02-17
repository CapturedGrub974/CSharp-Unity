using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    public bool m_isPickedUp;
    private Vector2 m_vel;
    public float m_smoothTime;

    void Update()
    {
        if (m_isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, m_player.transform.position + offset, ref m_vel, m_smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !m_isPickedUp)
        {
            m_isPickedUp = true;
            transform.SetParent(other.transform);
        }
    }
}
