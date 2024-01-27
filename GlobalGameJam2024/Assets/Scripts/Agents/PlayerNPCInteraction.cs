using UnityEngine;

public class PlayerNPCInteraction : PlayerAbility
{
    // Dist�ncia m�xima para interagir com NPCs
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
        // Verifica se o jogador pressionou a tecla de intera��o (pode ser ajustada conforme necess�rio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tenta interagir com um NPC
            TryInteractWithNPC();
        }
    }

    void TryInteractWithNPC()
    {
        // Obt�m todos os NPCs na �rea de intera��o
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionDistance);

        // Itera pelos NPCs encontrados
        foreach (Collider2D collider in colliders)
        {
            // Verifica se o NPC possui uma tag espec�fica (ajuste conforme necess�rio)
            if (collider.CompareTag("NPC"))
            {
                // Coloque aqui o c�digo de intera��o com o NPC
                Debug.Log("Interagindo com NPC: " + collider.gameObject.name);
            }
        }
    }
}
