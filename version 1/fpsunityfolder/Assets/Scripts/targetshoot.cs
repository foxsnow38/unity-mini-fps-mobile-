using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class targetshoot : MonoBehaviour
{


    public float health = 3f;
   
    public GameObject Healt2;
    public GameObject Healt3;
    
    private void Start()
    {
        

    }
    private void Update()
        {

            
        }
    public void TakeDamage(float amount)
    {
        Debug.Log("caný : " + health);
        health -= amount;
        if (health == 2)
        {
            Destroy(Healt3);
        }
        if (health == 1)
        {
            Destroy(Healt2);
        }
     
        if (health == 1 )
        {
            die();
        }
       }
    void die()
    {
      
        Destroy(gameObject,2f);

    }
    
  
    
    
    
}


