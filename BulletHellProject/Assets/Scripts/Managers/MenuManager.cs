using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToGame()
    {
        SceneLoader.Instance.LoadLevel("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Options()
    {
        Debug.Log("OPTIONS");
    }
}
