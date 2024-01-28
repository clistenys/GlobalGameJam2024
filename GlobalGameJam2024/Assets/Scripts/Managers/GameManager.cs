using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]PlayerController playerController;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public bool VerifyItem()
    {
        Debug.Log(playerController.HasItem());
        if (playerController.HasItem())
        {
            return true;
        }
        return false;
    }

    public void GetItem()
    {
        playerController.GetItem();
    }

    public void CallBoosScene()
    {
        SceneManager.LoadScene("ClistenysSampleScene");
    }
}
