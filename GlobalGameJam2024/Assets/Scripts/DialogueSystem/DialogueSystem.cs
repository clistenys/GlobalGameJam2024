using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueTitle;
    [SerializeField] TextMeshProUGUI dialogueText;

    private int actualPosition;
    
    void Start()
    {
        actualPosition = 0;
    }

    
    void Update()
    {
        
    }

    public bool StartDialogue(Dialogue dialogue)
    {
        Debug.Log(dialogue.dialogue[0] + " " + dialogueTitle.text);
        dialogueTitle.text = dialogue.title;

        actualPosition = 0;
        dialogueText.text = dialogue.dialogue[0];

        dialoguePanel.SetActive(true);

        if (actualPosition >= dialogue.dialogue.Count)
        {
            return true;
        }

        return false;
    }

    public bool NextText(Dialogue dialogue)
    {
        actualPosition++;
        
        if (actualPosition >= dialogue.dialogue.Count)
        {
            return true;
        }

        dialogueText.text = dialogue.dialogue[actualPosition];
        
        return false;
    }

    public void HidePanel()
    {
        actualPosition = 0;
        dialoguePanel.SetActive(false);
    }
}
