using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player;
    public bool locked;
    public AreaTransition areaTransition;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        areaTransition.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            locked = false;
            areaTransition.enabled = true;
        }
    }
}