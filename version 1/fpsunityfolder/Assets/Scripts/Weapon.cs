using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gun_Scriptes
{
    public class Weapon : MonoBehaviour

    
{
    public Gun[] loadout;
    public Transform weaponParrent;
    private GameObject CurrentWeapon;
        private int currentIndex;
        public GameObject BulletHolePrefab;
        public LayerMask CanShoot;
        public GameObject Bullet;
        public float BulletSpeed;
        public float BulletRange;
        public Camera fps_cam;
        public float spread;
        Vector3 targetpoint;
         Transform attackpoint;
        public float damage = 1f;

        bool bullet_aiming;
        // Start is called before the first frame update
        void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);



            if (CurrentWeapon != null)
            {
                Aim(Input.GetMouseButton(1));

                if (Input.GetMouseButtonDown(0))
                {
                   
                        //shoot();
                        bulletvisiual();
                    

                }
                 

                 
            }
    }
    void Equip(int p_ind) 
    {if (CurrentWeapon != null) Destroy(CurrentWeapon);
            currentIndex = p_ind;
        GameObject T_newEquipment = Instantiate(loadout[p_ind].prefab, weaponParrent.position, weaponParrent.rotation, weaponParrent) as GameObject;
        T_newEquipment.transform.localEulerAngles = Vector3.zero;
        T_newEquipment.transform.localPosition =Vector3.zero;
        CurrentWeapon = T_newEquipment;

                    


        }
        void Aim(bool p_isaiming) 
        {
            
           
            Transform t_state_ads = CurrentWeapon.transform.Find("states/ads");
            Transform t_state_hip = CurrentWeapon.transform.Find("states/hip");
            Transform t_anchor = CurrentWeapon.transform.Find("anchor");

            if (p_isaiming)
            {
                t_anchor.position = Vector3.Lerp(t_anchor.position, t_state_ads.position, Time.deltaTime * loadout[currentIndex].aimspeed);
                attackpoint = CurrentWeapon.transform.Find("states/atackpoint");
            }
            else
            {
                t_anchor.position = Vector3.Lerp(t_anchor.position, t_state_hip.position, Time.deltaTime * loadout[currentIndex].aimspeed);
                attackpoint = CurrentWeapon.transform.Find("states/atackpoint");
            }
        }
        void bulletvisiual()
        {
            attackpoint = CurrentWeapon.transform.Find("anchor/atackpoint"); 
            //GameObject newbullet = Instantiate(Bullet,t_anchor.position,Quaternion.identity) as GameObject;
            RaycastHit Bullet_hit = new RaycastHit();
            Transform t_spawn = transform.Find("Cameras/fpscamera");
            Ray ray = fps_cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0 ));
            if (Physics.Raycast(ray, out Bullet_hit))
            {
                Debug.Log(Bullet_hit.transform.name);
                targetpoint = Bullet_hit.point;
             targetshoot target =   Bullet_hit.transform.GetComponent<targetshoot>();
                //targetshoot target_collider = Bullet_hit.collider.gameObject.GetComponent<targetshoot>();
                if ( target !=null && Bullet_hit.collider.gameObject.tag == ("enemy"))
                {
                   //Bullet_hit.collider.gameObject.GetComponent
                    //target_collider.TakeDamage(damage);
                    target.TakeDamage(damage);
                }
            }
            else targetpoint = ray.GetPoint(75);
            Vector3 DirectionWitoutSpread = targetpoint - attackpoint.position;
            float x = Random.Range(-spread, spread);
            float y= Random.Range(-spread, spread);
            Vector3 DirectionWithSpread = DirectionWitoutSpread + new Vector3(x, y, 0);
            GameObject currentBullet = Instantiate(Bullet, attackpoint.position, Quaternion.identity);
            currentBullet.transform.forward = DirectionWithSpread.normalized;
            currentBullet.GetComponent<Rigidbody>().AddForce(DirectionWithSpread.normalized*BulletSpeed,ForceMode.Impulse);
       
        }
        void shoot()
        {
            Transform t_spawn = transform.Find("Cameras/fpscamera");
            RaycastHit t_hit = new RaycastHit();
            if(Physics.Raycast(t_spawn.position,t_spawn.forward,out t_hit, 1000f, CanShoot)) 
            {
                GameObject newbullethole = Instantiate(BulletHolePrefab, t_hit.point + t_hit.normal * 0.001f, Quaternion.identity) as GameObject;
                newbullethole.transform.LookAt(t_hit.point + t_hit.normal);
                Destroy(newbullethole, 30f);
                
            }
        
        }
        }
}
