using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public GameObject playerModel;
    public bool isFacingRight;

    public void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Verifica se a entrada excede um valor de sensibilidade
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            // Calcula a direção do movimento
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize();

            transform.position += movement * speed * Time.deltaTime;
        }
    }

    void Flip()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
            playerModel.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Input.GetAxisRaw("Horizontal") < 0)
            playerModel.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

}
