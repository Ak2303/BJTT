using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void onBack(){
        SceneManager.LoadScene(0);
    }

    public void onQuit(){
        Debug.Log("Quit!!");
        Application.Quit();
    }

    public void onRulebook(){

    }

    public void onHelp(){

    }

    public void onCircuit(){

    }
}
