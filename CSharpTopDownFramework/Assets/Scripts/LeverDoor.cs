using UnityEngine;
using System.Collections;

public class LeverDoor : MonoBehaviour
{
    [SerializeField]private bool m_isOpen = false;

    public void OpenDoor()
    {
        if (!m_isOpen)
        {
            Destroy(gameObject);
        }
    }
}