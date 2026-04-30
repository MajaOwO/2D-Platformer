using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float health;
    private bool canReceiveDamage = true;
    public float InvincibilityTime = 2;
    private float Coins;




    public delegate void HealthChangeHandler(float newHealth, float amountChange);
    public event HealthChangeHandler OnHealthChanged;

    public delegate void HealthInitializedHandler(float newHealth);
    public event HealthInitializedHandler OnHealthInitialized;

    public delegate void CoinChangedHandler(float addcoin);
    public event CoinChangedHandler OnCoinChanged;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = MaxHealth;
        OnHealthInitialized?.Invoke(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddDamage(float damage)
    {
       
        if (canReceiveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(InvincibilityTime, ResetInvincibility));
        }
        Debug.Log(health);
    }
     IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }
    private void ResetInvincibility()
    {
        canReceiveDamage = true;
    }


    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnHealthChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);

    }
    public void CoinAmount(float addcoin)
    {
        Coins += addcoin;
        OnCoinChanged?.Invoke(Coins);
        Debug.Log(Coins);
    }


}

