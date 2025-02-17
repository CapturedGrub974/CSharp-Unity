using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject m_player;
    public bool m_locked;
    public AreaTransition m_areaTransition;

    void Start()
    {
        m_locked = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Key key = other.GetComponentInChildren<Key>();
            if (other.gameObject.CompareTag("Key"))
            {
                
            }

            if (key != null && key.m_isPickedUp)
            {
                Destroy(key.gameObject);
                m_locked = false;
                m_areaTransition.m_isEnabled = true;
            }
        }
    }
}