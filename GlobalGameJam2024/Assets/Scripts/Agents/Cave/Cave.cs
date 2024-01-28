using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private bool isInArea;

    void Start()
    {
        isInArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInArea && gameManager.VerifyItem())
        {
            StartInteract();
        }
    }

    private void StartInteract()
    {
        gameManager.CallBoosScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            isInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            isInArea = false;
        }
    }
}
