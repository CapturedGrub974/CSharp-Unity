using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    private CameraController m_camera;
    public Vector2 m_newMinPos;
    public Vector2 m_newMaxPos;
    public Vector3 m_movePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_camera = GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
}
