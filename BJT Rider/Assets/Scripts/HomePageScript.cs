using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePageScript : MonoBehaviour
{
    public PlayFabManager playFab;

    public void OnStartClick(){
        SceneManager.LoadScene("NPNActiveTrack");
    }

    public void OnSettings(){
        SceneManager.LoadScene("HelpScene");
    }


    public void OnLogoutClick(){
        playFab.OnLogoutButton();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
