using UnityEngine;

public class PlayerItemCollection : MonoBehaviour
{
    // Dist�ncia m�xima para coletar itens
    public float collectionDistance = 2f;

    void Update()
    {
        // Verifica se o jogador pressionou a tecla de coleta (pode ser ajustada conforme necess�rio)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Tenta coletar itens na �rea
            TryCollectItems();
        }
    }

    void TryCollectItems()
    {
        // Obt�m todos os itens na �rea de coleta
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collectionDistance);

        // Itera pelos itens encontrados
        foreach (Collider2D collider in colliders)
        {
            // Verifica se o item possui uma tag espec�fica (ajuste conforme necess�rio)
            if (collider.CompareTag("Item"))
            {
                // Coloque aqui o c�digo de coleta do item
                Debug.Log("Coletando item: " + collider.gameObject.name);

                // Adicione aqui a l�gica de coleta, como adicionar o item ao invent�rio
                // e, opcionalmente, desativar ou destruir o GameObject do item coletado
                collider.gameObject.SetActive(false);
            }
        }
    }
}
