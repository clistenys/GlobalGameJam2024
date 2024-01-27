using UnityEngine;

public class Health: MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima
    private int currentHealth;   // Vida atual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida máxima no início
    }

    public void TakeDamage(int damage)
    {
        // Reduz a vida atual com base no dano recebido
        currentHealth -= damage;

        // Verifica se a entidade ainda está viva
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Adicione aqui a lógica de morte (por exemplo, desativar o GameObject, exibir uma animação, etc.)
        Debug.Log(gameObject.name + " morreu!");
    }

    public void Heal(int amount)
    {
        // Adiciona vida à entidade
        currentHealth += amount;

        // Garante que a vida atual não exceda a vida máxima
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // Método para obter a vida atual
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Método para obter a vida máxima
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
