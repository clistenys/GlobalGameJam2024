using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed = 10f;  // Velocidade padr�o

    void Update()
    {
        // Move o projetil para frente ao longo do eixo de sua rota��o
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        // M�todo para configurar a velocidade do projetil
        speed = newSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // L�gica de colis�o do projetil com outros objetos, se necess�rio
        if (other.tag == "Player")
        {
            // Por exemplo, causar dano ao jogador
            Destroy(gameObject);
        }
    }
}
