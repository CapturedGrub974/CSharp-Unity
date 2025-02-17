using UnityEngine;

public class AreaTransitionUnlocked : MonoBehaviour
{
    public Vector3 m_movePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position += m_movePlayer;
        }
    }
}
