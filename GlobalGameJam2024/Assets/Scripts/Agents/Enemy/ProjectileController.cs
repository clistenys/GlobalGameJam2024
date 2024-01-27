using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed = 10f;  // Velocidade padrão

    void Update()
    {
        // Move o projetil para frente ao longo do eixo de sua rotação
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        // Método para configurar a velocidade do projetil
        speed = newSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Lógica de colisão do projetil com outros objetos, se necessário
        if (other.tag == "Player")
        {
            // Por exemplo, causar dano ao jogador
            Destroy(gameObject);
        }
    }
}
