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

    private bool hasItem;

    void Start()
    {
        // Obtém as referências aos componentes necessários
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
        playerHealth = GetComponent<Health>();

        canMove = true;
        canAtack = true;
        hasItem = false;
    }

    void Update()
    {
        HandleMovement();
        HandleCombat();

        Debug.Log(playerHealth.GetCurrentHealth());
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

    public void GetItem()
    {
        hasItem = true;
    }

    public bool HasItem()
    {
        return hasItem;
    }
}
