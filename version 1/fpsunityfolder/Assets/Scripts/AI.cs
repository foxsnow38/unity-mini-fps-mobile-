using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Gun_Scriptes
{
    public class AI : MonoBehaviour
    {
        [Header("Oto Bakýþ")]
        public float AiRange = 15f;
        public Transform ShootThis;
        public Transform Rot_EnemyCam;






        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
            Randoms();
            color();

        }
        

        // Update is called once per frame
        void UpdateTarget()
        { 
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            float shortesdistance = Mathf.Infinity;
            GameObject NearestPlayer = null;


            foreach (GameObject player in players)
            {
                float distancetoplayer = Vector3.Distance(transform.position, player.transform.position);

                if (distancetoplayer < shortesdistance)
                {

                    shortesdistance = distancetoplayer;
                    NearestPlayer = player;

                }
                if (NearestPlayer != null && shortesdistance <= AiRange)
                {
                    ShootThis = NearestPlayer.transform;
                }
                //else { ShootThis = null; }
            }
        }
        void Update()
        {
            if (ShootThis == null)
                return;
            LookTarget();
            if (fireCountDown <= 0f)
            {
                shoottoPlayer();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;


            moveif();
            


        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, AiRange);
        }
        void LookTarget()
        {
            Vector3 EnemyDirection = ShootThis.position - transform.position;
            Quaternion lookrotation = Quaternion.LookRotation(EnemyDirection);
            Vector3 Rotations = lookrotation.eulerAngles;
            Rot_EnemyCam.rotation = Quaternion.Euler(0f, Rotations.y, 0f);

        }
        [Header("Oto Ateþ")]
        public string EnemyTag = "enemy";
        public float fireRate = 1f;
        private float fireCountDown = 0f;
        //Bullet Spawn Location
        public GameObject BulletPreFab;
        public Transform AttackPoint;
        void shoottoPlayer()
        {
            GameObject SpawnBullet = Instantiate(BulletPreFab, AttackPoint.position, AttackPoint.rotation);
            SpawnBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);


        }

        public float MoveSpeed = 4f;
        Vector3 gidilecekPozisyon;
        bool aradakimesafeyibirkereal = true;
        Vector3 aradakimesafe;
        bool x = true;
        void  moveif()
        {
            Scene Mainscene = SceneManager.GetSceneByName("menu");

            if (SceneManager.GetActiveScene() == Mainscene)
            { StartCoroutine("move");
               
            }

            else if (x == true)
            {
                StartCoroutine("move");
                x = false;
            }

            else if (x == false)
            {
                x = true;
                StartCoroutine("MoveToward");

            }

           

        }
        IEnumerator move()
        {
             
            if (aradakimesafeyibirkereal == true)
            {
                CreatePosition();
                aradakimesafe = (gidilecekPozisyon - transform.position).normalized;                
                aradakimesafeyibirkereal = false;
            }

            float mesafe = Vector3.Distance(transform.position, gidilecekPozisyon);
            transform.position += aradakimesafe * Time.deltaTime * MoveSpeed;

            if (mesafe < 0.5f)
            {
                 aradakimesafeyibirkereal = true;
                MoveSpeed = 0;
                yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
                MoveSpeed = 4;
              
            }

           
        }
        
       IEnumerator MoveToward()
        {
            transform.position = Vector3.MoveTowards(transform.position, ShootThis.position, 5f* Time.deltaTime);
            yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));
        }


        void CreatePosition()
        {
            gidilecekPozisyon = new Vector3(Random.Range(-40, 34), 2.5f, Random.Range(-37, 37));
        }
         public GameObject enemyColor;
        void color()
        {
            
                if (a ==1)
            {
                enemyColor.GetComponent<Material>().SetColor("_Color", Color.blue);

            }
                else if(a == 3)
            { enemyColor.GetComponent<Material>().SetColor("_Color", Color.red); }
            else if (a == 4)
            { enemyColor.GetComponent<Material>().SetColor("_Color", Color.yellow); }
            else if (a == 5)
            { enemyColor.GetComponent<Material>().SetColor("_Color", Color.green); }
            else if (a == 2)
            { enemyColor.GetComponent<Material>().SetColor("_Color", Color.black); }

            /*enemyColor.GetComponent<Material>.color */
          
        }
        public int a;
        void Randoms()
        {
             a = Random.RandomRange(1, 5);
        }



    }
}

