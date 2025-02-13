using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera m_mainCam;
    private Vector3 m_mousePos;
    public GameObject m_arrow;
    public Transform m_firePoint;
    public bool m_canFire;
    private float m_timer;
    public float m_timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        m_mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        m_mousePos = m_mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = m_mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);

        if (!m_canFire)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_timeBetweenFiring)
            {
                m_canFire = true;
                m_timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && m_canFire)
        {
            m_canFire = false;
            Instantiate(m_arrow, m_firePoint.position, Quaternion.identity);
        }
    }
}
