using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDies : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        dies();
    }
        
        
    public GameObject Player;
    
    void dies()
    {
        if (Player == null)
        { SceneManager.LoadScene(0); }
    }
}
