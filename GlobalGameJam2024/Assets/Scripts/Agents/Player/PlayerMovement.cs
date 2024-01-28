using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float speed = 5f;
    private bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public GameObject playerModel;
    public bool isFacingRight;

    public void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Verifica se a entrada excede um valor de sensibilidade
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            animator.SetBool("isWalking", true);
            // Calcula a direção do movimento
            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            movement.Normalize();

            transform.position += movement * speed * Time.deltaTime;

            if(horizontalInput < 0 && isFacingRight)
            {
                Flip();
            }

            if(horizontalInput > 0 && !isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

<<<<<<< Updated upstream
    void Flip()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
            playerModel.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Input.GetAxisRaw("Horizontal") < 0)
            playerModel.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

=======
    public void Flip()
    {
        // Inverte a escala horizontal do objeto
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        // Atualiza a flag de direção
        isFacingRight = !isFacingRight;
    }
>>>>>>> Stashed changes
}
