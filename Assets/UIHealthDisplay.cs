using UnityEngine;
using TMPro;
using System;

public class UIHealthDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;

    void Start()
    {
        playerHealth.OnHealthChanged += OnHealtChanged;
        playerHealth.OnHealthInitialized += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
      healthText.text = newHealth.ToString();
    }

    public void OnHealtChanged(float newHealth, float amountChange)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();

    }


}
