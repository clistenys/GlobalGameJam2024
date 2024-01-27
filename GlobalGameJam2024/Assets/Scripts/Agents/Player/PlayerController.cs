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
        // Obtém as referências aos componentes necessários
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
