using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public Vector3 m_movePlayer;
    public bool m_isEnabled = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && m_isEnabled)
        {
            other.transform.position += m_movePlayer;
        }
    }
}
