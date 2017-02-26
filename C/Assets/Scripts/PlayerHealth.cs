using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Don't touch")]
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    public float percent = 0;

    private GameObject healthBar;
    private RectTransform healthBarTrans;

    void OnEnable()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTrans = healthBar.GetComponent<RectTransform>();
    }

    /*void OnLevelWasLoaded()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTrans = healthBar.GetComponent<RectTransform>();
    }*/

    void Update()
    {
        //UpdateDisplay();  //not necessary because it's called within the addhealth & takedamage methods
    }

    //Called by health pickups
    public void AddHealth(float newHealth)
    {
        currentHealth += newHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateDisplay();
    }

    //Called by spikes or enemies
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
        }
        UpdateDisplay();
        //SceneManager.LoadScene(1);
    }

    //Update UI element
    void UpdateDisplay()
    {
        percent = (currentHealth / maxHealth) * 79.5f;  //76.6f
        healthBarTrans.sizeDelta = new Vector2(100, percent);
    }
}