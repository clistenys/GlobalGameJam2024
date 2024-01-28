using UnityEngine;

public class Health: MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Audio Sources")]
    public AudioSource SfxAudioSource;

    [Header("Feedbacks")]
    public AudioClip takeDamageSfx;
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        SfxAudioSource.clip = takeDamageSfx;
        SfxAudioSource.Play();

        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0f)
        {
            SfxAudioSource.clip = takeDamageSfx;
            SfxAudioSource.Play();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // Método para obter a vida atual
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
