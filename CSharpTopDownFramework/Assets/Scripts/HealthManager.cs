using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    //Makes the sprite flash when player takes damage
    void Update()
    {
        if (flashActive)
        {
            if ((int)(100 * flashCounter / 16) % 2 == 0)
            { playerSprite.color = new Color(1f, 1f, 1f, 1f); }
            else
            { playerSprite.color = new Color(1f, 1f, 1f, 0f); }
            if (flashCounter <= 0)
            {
                playerSprite.color = new Color(1f, 1f, 1f, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void IncreaseHealth(int v)
    {
        currentHealth += v;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        //decreases health by damage on projectile
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        //if health falls to 0, destroy player object and load death scene
        if (currentHealth <= 0)
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
    }
}