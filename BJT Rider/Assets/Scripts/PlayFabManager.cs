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
    public InputField nameInput;
    
    public GameObject rowPrefab;
    public Transform rowParent;
    public GameObject playerRowPrefab;
    public Transform playerRowParent;


    public void registerButton(){
        if(Email.text.Length == 0){
            ErrorMessage.text = "Enter Email";
            Invoke("DisableText", 5f);
            return;
        }

        if(Password.text.Length < 6){
            ErrorMessage.text = "Password too short";
            Invoke("DisableText", 5f);                
            return ;
        }

        Email.text = Email.text + "@iitj.ac.in";
        var request = new RegisterPlayFabUserRequest{
            Email = Email.text,
            Password = Password.text, 
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);

    } 

    void OnRegisterSuccess(RegisterPlayFabUserResult result){
        ErrorMessage.text = "Registered successfully and Loggedin!!!!!";
        SendLeaderboard(50);
        SceneManager.LoadScene("WelcomeScene");
    }
    

    public void loginButton(){
        Email.text = Email.text + "@iitj.ac.in";    
        var request = new LoginWithEmailAddressRequest{
            Email = Email.text,
            Password = Password.text, 
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }


    void OnLoginSuccess(LoginResult result){
        ErrorMessage.text = "LoggedIn!!!";
        Debug.Log("Successful Login/Account created");
        SceneManager.LoadScene("HomePage");
                      
    }


    public void OnLogoutButton(){
        PlayFabClientAPI.ForgetAllCredentials();
        SceneManager.LoadScene("LoginScene");
    }

    public void SubmitNameButton(){
        var request=new UpdateUserTitleDisplayNameRequest{
            DisplayName=nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request,OnDisplayNameUpdate,OnError); 
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result){
        Debug.Log("Display Name updated");
        SceneManager.LoadScene("HomePage");
    }


    public void resetPasswordButton(){
        Email.text = Email.text + "@iitj.ac.in";
        var request = new SendAccountRecoveryEmailRequest{
            Email = Email.text,
            TitleId = "385E8", 
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result){
        
        ErrorMessage.text = "Account Recovery Email Sent!!";
        
    }
    
    public void SendLeaderboard(int score){
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "Scoreboard", 
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);//haa accha
    }
    

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result){
        Debug.Log("Successful leaderboard sent!!");
    }

    //sb h
    
    

    public void GetLeaderboard(){
        var request = new GetLeaderboardRequest{
            StatisticName = "Scoreboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result){
        foreach (Transform item in rowParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {   
            GameObject newGo = Instantiate(rowPrefab, rowParent);
            Text[]texts = newGo.GetComponentsInChildren<Text>();//ye line dekh
            texts[0].text = (item.Position +1).ToString();
            texts[1].text = (item.DisplayName);
            texts[2].text = (item.StatValue).ToString();
            Debug.Log(item.Position + 1 + " " + item.PlayFabId + " " + item.StatValue);//
        }
    }

    public void GetLeaderboardScore(){
        var request = new GetLeaderboardAroundPlayerRequest{
            StatisticName = "Scoreboard",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardScoreGet, OnError);
    }

    void OnLeaderboardScoreGet(GetLeaderboardAroundPlayerResult result){
        foreach (Transform item in playerRowParent)
        {
            Destroy(item.gameObject);
        }
        
        foreach (var item in result.Leaderboard)
        {   
            GameObject newGo = Instantiate(playerRowPrefab, playerRowParent);
            Text[]texts = newGo.GetComponentsInChildren<Text>();//ye line dekh
            texts[0].text = (item.Position +1).ToString();//
            texts[1].text = (item.DisplayName);
            texts[2].text = (item.StatValue).ToString();
            Debug.Log(item.Position + 1 + " " + item.PlayFabId + " " + item.StatValue);//
        }
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
