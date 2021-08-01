using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Gun_Scriptes
{
    public class BulletCollison : MonoBehaviour
{
        public string BulletTag = "EnemyBullet";
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider col_object)
    {
        if (col_object.CompareTag("Player") )
        {
                float buLLetDamAge = 1f;
                col_object.GetComponent<targetshoot>().TakeDamage(buLLetDamAge);
            
            
        }
        //else if (col_object.CompareTag("enemy"))
        //        {
        //        float buLLetDamAge = 1f;
        //        col_object.GetComponent<targetshoot>().TakeDamage(buLLetDamAge);
        //    }
       
    }

}
}
