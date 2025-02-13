using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player;
    public bool locked;
    public AreaTransition areaTransition;

    void Start()
    {
        locked = true;
        areaTransition.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Key key = other.GetComponentInChildren<Key>();
            if (other.gameObject.CompareTag("Key"))
            {
                locked = false;
                areaTransition.enabled = true;
            }

            if (key != null && key.isPickedUp)
            {
                Destroy(key.gameObject);
            }
        }
        
    }
}