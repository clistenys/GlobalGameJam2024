using UnityEngine;

public class Health: MonoBehaviour
{
    public int maxHealth = 100; // Vida m�xima
    private int currentHealth;   // Vida atual

    void Start()
    {
        currentHealth = maxHealth; // Inicializa a vida atual com a vida m�xima no in�cio
    }

    public void TakeDamage(int damage)
    {
        // Reduz a vida atual com base no dano recebido
        currentHealth -= damage;

        // Verifica se a entidade ainda est� viva
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Adicione aqui a l�gica de morte (por exemplo, desativar o GameObject, exibir uma anima��o, etc.)
        Debug.Log(gameObject.name + " morreu!");
    }

    public void Heal(int amount)
    {
        // Adiciona vida � entidade
        currentHealth += amount;

        // Garante que a vida atual n�o exceda a vida m�xima
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // M�todo para obter a vida atual
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // M�todo para obter a vida m�xima
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
