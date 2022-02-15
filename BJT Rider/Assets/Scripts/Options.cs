using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;             
// using UnityEngine.InputSystem.Controls; 
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void onBack(){
        // InputSystem. EnableDevice(Keyboard. current);
        // SceneManager.LoadScene(0);
        
    }
    public void onOption(){
        // InputSystem. DisableDevice(Keyboard. current);
    }

    public void onQuit(){
        Debug.Log("Quit!!");
        SceneManager.LoadScene("HomePage");
    }
    

    public void onRulebook(){

    }

    public void onHelp(){

    }

    public void onCircuit(){

    }
}
