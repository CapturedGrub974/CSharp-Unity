using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public Vector3 m_movePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position += m_movePlayer;
        }
    }
}
