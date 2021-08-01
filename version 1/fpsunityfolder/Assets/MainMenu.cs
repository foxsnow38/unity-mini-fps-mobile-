using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Settings_Ui
{
    public class MainMenu : MonoBehaviour
    { public GameObject SettingsDisable;
        public Text MouseSensNumber;
        private string str_sensnumber = "";


        
        public void Start()
        {

            fpsplayerlook.sens = 500f;
           
            SettingsDisable.active = false;
        }
        public float aex = 1f;
        public void Update()
        {
            
            str_sensnumber = aex.ToString();
        }
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }



        public void SetSens(float NewSens)
        {
            aex = NewSens;
            PlayerPrefs.SetFloat("sensivity", aex);
            PlayerPrefs.GetFloat("sensivity", fpsplayerlook.sens);

        }
            public void QuitGame()
        {
            Debug.Log("Quit!!!!");
            Application.Quit();
        }
    }
}