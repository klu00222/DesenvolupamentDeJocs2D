using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public static event Action<int> OnLifeChanged;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        LifeEventEmitter.OnTakeDamage += TakeDamage;
        LifeEventEmitter.OnHeal += Heal;
    }

    private void OnDisable()
    {
        LifeEventEmitter.OnTakeDamage -= TakeDamage;
        LifeEventEmitter.OnHeal -= Heal;
    }

    private void TakeDamage()
    {
        currentHealth -= Random.Range(0, maxHealth);
        if (currentHealth < 0) currentHealth = 0;

        OnLifeChanged?.Invoke(currentHealth);
    }

    private void Heal()
    {
        currentHealth += Random.Range(0, maxHealth);
        if (currentHealth > maxHealth) currentHealth = maxHealth;

        OnLifeChanged?.Invoke(currentHealth);
    }
}
