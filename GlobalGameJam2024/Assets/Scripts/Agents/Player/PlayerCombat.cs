using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator bossAnimator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackCooldown = 1f;
    private float nextAttackTime = 0f;

    public void Attack()
    {
        if (Input.GetButtonDown("Attack") && Time.time >= nextAttackTime)
        {
            Debug.Log("atacou");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                // Obtém a referência ao componente Health do inimigo
                Health enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    // Aplica dano ao inimigo
                    enemyHealth.TakeDamage(20); // Ajuste conforme necessário
                    bossAnimator.SetBool("takeDamage", true);
                    StartCoroutine(BackToIdleAnimation());

                    if (enemyHealth.currentHealth <= 0)
                    {
                        Debug.Log(enemy.name + " morreu!");
                        Destroy(enemy.gameObject);
                    }
                }
            }

            nextAttackTime = Time.time + attackCooldown;
        }
        
    }

    public IEnumerator BackToIdleAnimation()
    {
        yield return new WaitForSeconds(1f);
        bossAnimator.SetBool("takeDamage", false);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
