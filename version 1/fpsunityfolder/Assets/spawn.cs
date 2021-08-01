using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawns());
        StartCoroutine(thirtySec());
        StartCoroutine(TimerFunc());
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public GameObject EnemyPrefab;
    public float enemy_spawn_level = 10f;
    public bool thirt = false;
   
    IEnumerator spawns()
    {

        
        if (thirt == true)
        {
            if (enemy_spawn_level >= 1)
            { enemy_spawn_level = enemy_spawn_level - 1; }

            else
            { enemy_spawn_level = 1; }
            thirt = false;
        }


        Instantiate(EnemyPrefab, new Vector3(Random.Range(-40, 34), 2.5f, Random.Range(-37, 37)), Quaternion.identity);
        yield return new WaitForSeconds(enemy_spawn_level);
        StartCoroutine(spawns());
        
    }

    IEnumerator thirtySec()
    {
        thirt = true;
        yield return new WaitForSeconds(30);
        StartCoroutine(thirtySec());
    }
    private int minute = 0;
    private int timer = 0;
    private string timesnow = "", zero, twodot;
    public bool time_thirtysec = false;
    public Text TimerText;
    IEnumerator TimerFunc()
    {
        zero = "0";
        twodot = ":";
        timer = timer + 1;
        if (timer == 60)
        { minute = minute + 1; timer = 0; }
        if (minute >= 10)
        {
            timesnow = (minute + twodot + timer).ToString();
            TimerText.text = timesnow;
        }
        else
        {
            timesnow = (zero + minute + twodot + timer).ToString();
            TimerText.text = timesnow;
        }
        if (timer == 30) time_thirtysec = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(TimerFunc());
    }
   






}
