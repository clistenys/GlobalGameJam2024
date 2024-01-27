using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Permitions")]
    public bool canMove;
    public bool canAtack;

    [Header("Abilities")]
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private Health playerHealth;

    void Start()
    {
        // Obt�m as refer�ncias aos componentes necess�rios
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        playerHealth = GetComponent<Health>();

        canMove = true;
        canAtack = true;
    }

    void Update()
    {
        HandleMovement();
        HandleCombat();
    }

    void HandleMovement()
    {
        if (canMove) 
            playerMovement.Move();
    }

    void HandleCombat()
    {
        if (canAtack)
            playerCombat.Attack();
    }
}
