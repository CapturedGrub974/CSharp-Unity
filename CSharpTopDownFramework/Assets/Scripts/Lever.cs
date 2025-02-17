using UnityEngine;

public class Lever : MonoBehaviour
{
    public LeverDoor[] m_door;
    public bool m_isActivated;
    private SpriteRenderer m_spriteRenderer;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerWeapon") && !m_isActivated)
        {
            m_spriteRenderer.flipY = !m_spriteRenderer.flipY;
            m_isActivated = true;

            foreach (LeverDoor door in m_door)
            {
                door.OpenDoor();
            }
        }
    }
}
