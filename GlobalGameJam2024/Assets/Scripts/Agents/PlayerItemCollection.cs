using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
    // Distância máxima para coletar itens
    public float collectionDistance = 2f;

    void Update()
    {
        // Verifica se o jogador pressionou a tecla de coleta (pode ser ajustada conforme necessário)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Tenta coletar itens na área
            TryCollectItems();
        }
    }

    void TryCollectItems()
    {
        // Obtém todos os itens na área de coleta
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collectionDistance);

        // Itera pelos itens encontrados
        foreach (Collider2D collider in colliders)
        {
            // Verifica se o item possui uma tag específica (ajuste conforme necessário)
            if (collider.CompareTag("Item"))
            {
                // Coloque aqui o código de coleta do item
                Debug.Log("Coletando item: " + collider.gameObject.name);

                // Adicione aqui a lógica de coleta, como adicionar o item ao inventário
                // e, opcionalmente, desativar ou destruir o GameObject do item coletado
                collider.gameObject.SetActive(false);
            }
        }
    }
}
