using UnityEngine;

public class PlayerMovement : PlayerAbility
{
    public float speed = 5f; // Velocidade de movimento do jogador
    public float x, y;

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

        // Obtém as entradas do teclado
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        x = horizontalInput;
        y = verticalInput;

        // Verifica se a entrada excede um valor de sensibilidade
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            // Calcula a direção do movimento
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize();

            // Move o jogador
            transform.position += movement * speed * Time.deltaTime;
        }
        else
        {
            // Se a entrada não excede o valor de sensibilidade, o jogador não deve se mover
            // Defina a posição diretamente para evitar inércia
            transform.position = transform.position;
        }
    }
}
