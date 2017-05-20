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

    private Death deathScript;

    void OnEnable()
    {
        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTrans = healthBar.GetComponent<RectTransform>();

        deathScript = GameObject.FindGameObjectWithTag("Death").GetComponent<Death>();
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
            SceneManager.LoadScene(deathScript.getSceneNum());
        }
        UpdateDisplay();
    }

    //Update UI element
    void UpdateDisplay()
    {
        percent = (currentHealth / maxHealth) * 79.5f;  //76.6f
        healthBarTrans.sizeDelta = new Vector2(100, percent);
    }
}