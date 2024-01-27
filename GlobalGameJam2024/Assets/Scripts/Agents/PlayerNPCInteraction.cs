using UnityEngine;

public class PlayerNPCInteraction : PlayerAbility
{
    // Distância máxima para interagir com NPCs
    public float interactionDistance = 2f;

    public override void Start()
    {
        base.Start();

        Initialize();
    }

    private void Initialize()
    {
        canUse = true;
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla de interação (pode ser ajustada conforme necessário)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tenta interagir com um NPC
            TryInteractWithNPC();
        }
    }

    void TryInteractWithNPC()
    {
        // Obtém todos os NPCs na área de interação
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);

        // Itera pelos NPCs encontrados
        foreach (Collider2D collider in colliders)
        {
            // Verifica se o NPC possui uma tag específica (ajuste conforme necessário)
            if (collider.CompareTag("NPC"))
            {
                // Coloque aqui o código de interação com o NPC
                Debug.Log("Interagindo com NPC: " + collider.gameObject.name);
            }
        }
    }
}
