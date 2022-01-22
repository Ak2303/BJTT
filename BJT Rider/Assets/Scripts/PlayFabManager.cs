using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    public Text ErrorMessage;
    public InputField Email;
    public InputField Password;
    public void registerButton(){
        if(Email.text.Length == 0){
            ErrorMessage.text = "Enter Email";
            Invoke("DisableText", 5f);
            return;//crypto:)
        }

        if(Password.text.Length < 6){
            ErrorMessage.text = "Password too short";
            Invoke("DisableText", 5f);                
            return ;
        }
        var request = new RegisterPlayFabUserRequest{
            Email = Email.text,
            Password = Password.text, 
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);

    } 

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        ErrorMessage.text = "Registered successfully and Loggedin!!!!!";
        SceneManager.LoadScene("NPNActiveTrack");
    }
    

    public void loginButton(){
        var request = new LoginWithEmailAddressRequest{
            Email = Email.text,
            Password = Password.text, 
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }


    void OnLoginSuccess(LoginResult result){
        ErrorMessage.text = "LoggedIn!!!";
        Debug.Log("Successful Login/Account created");
        SceneManager.LoadScene("NPNActiveTrack");               
    }

    public void resetPasswordButton(){
        var request = new SendAccountRecoveryEmailRequest{
            Email = Email.text,
            TitleId = "385E8", 
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result){
        //bccha dhyaan se .... aapko bol rha mo...dhyaan rkhiye ...ik mo ...
        ErrorMessage.text = "Account Recovery Email Sent!!";
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnError(PlayFabError error){
        ErrorMessage.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
        Invoke("DisableText", 5f);
    }

    void DisableText()
   { 
      ErrorMessage.text = ""; 
   }

}
