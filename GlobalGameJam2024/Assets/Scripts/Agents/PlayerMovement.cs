using UnityEngine;

public class PlayerMovement : PlayerAbility
{
    public float speed = 5f; // Velocidade de movimento do jogador

    public override void Start()
    {
        base.Start();

        Initialize();
    }

    private void Initialize()
    {
        canUse = true;
    }


    public void Move()
    {
        if (!canUse)
            return;

        // Obt�m as entradas do teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula a dire��o do movimento
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        movement.Normalize(); // Normaliza para garantir que a velocidade seja consistente em todas as dire��es

        // Move o jogador
        transform.position += movement * speed * Time.deltaTime;
    }
}
