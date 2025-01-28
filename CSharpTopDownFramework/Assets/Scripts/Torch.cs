using UnityEngine;
using UnityEngine.InputSystem;

public class Torch : MonoBehaviour
{
    [SerializeField] private Transform m_torchLight;
    private Transform m_torchCenter;
    private Vector3 mousePos;
    [SerializeField] private Transform playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePointOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 torchDirection = (mousePointOnScreen - playerPos.position);

        float angle = Mathf.Atan2(torchDirection.y, torchDirection.x) * Mathf.Rad2Deg;
        m_torchLight.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
