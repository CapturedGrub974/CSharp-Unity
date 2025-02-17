using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthManager m_healthMan;
    public Slider m_healthBar;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        m_healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_healthBar.maxValue = m_healthMan.maxHealth;
        m_healthBar.value = m_healthMan.currentHealth;
        hpText.text = "HP: " + m_healthMan.currentHealth + "/" + m_healthMan.maxHealth;
    }
}
