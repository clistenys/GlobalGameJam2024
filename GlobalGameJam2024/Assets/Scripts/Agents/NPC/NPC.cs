using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] DialogueSystem dialogueSystem;
    [SerializeField] Dialogue dialogue;
    private bool isInArea, isActive, isFinished;

    // Start is called before the first frame update
    void Start()
    {
        isInArea = false;
        isActive = false;
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInArea && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (!isFinished)
            {
                if (isActive)
                {
                    NextText();
                }
                else
                {
                    StartInteract();
                }
            }
            else
            {
                dialogueSystem.HidePanel();
                isActive = false;
                isFinished = false;
            }
        }
    }

    private void StartInteract()
    {
        isActive = true;
        isFinished = dialogueSystem.StartDialogue(dialogue);
        if(isFinished)
        {
            dialogueSystem.HidePanel();
            isActive = false;
            isFinished = false;
        }
    }

    private void NextText()
    {
        isFinished = dialogueSystem.NextText(dialogue);
        if (isFinished)
        {
            dialogueSystem.HidePanel();
            isActive = false;
            isFinished = false;
        }
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
            isActive = false;
            isFinished = false;
            dialogueSystem.HidePanel();
        }
    }
}
