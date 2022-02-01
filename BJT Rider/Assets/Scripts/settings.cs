using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour
{
    //Button on the Settings/Help UI
    public void OnBack(){
        SceneManager.LoadScene("HomePage");
    }

    public void OnQuit(){
        Application.Quit();
    }

}
