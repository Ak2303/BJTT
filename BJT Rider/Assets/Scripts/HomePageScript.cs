using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;


public class HomePageScript : MonoBehaviour
{
    public PlayFabManager playFab;
    public int score;
    public int level;
    public void OnStartClick(){
        StartScore();
        score=score*-1;
        playFab.SendLeaderboard(score);
        SceneManager.LoadScene("NPNActiveTrack");
    }

    void OpenScene(int level){
        Debug.Log(level);
        if(level == 0){
            SceneManager.LoadScene("NPNActiveTrack");
        }else if(level == 1){
            SceneManager.LoadScene("NPNCutoff");
        }else if(level == 2){
            SceneManager.LoadScene("NPNSaturation");
        }else if(level == 3){
            SceneManager.LoadScene("PNPActive");
        }else if(level == 4){
            SceneManager.LoadScene("PNPCutoff");
        }else if(level == 5){
            SceneManager.LoadScene("PNPSaturation");
        }else{
            // this.SetActive(false);
        }
    }
    public void OnResumeClick(){
        getProgress();
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


    public void StartScore(){
        var request = new GetLeaderboardAroundPlayerRequest{
            StatisticName = "Scoreboard",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnStartScoreGet, OnError);
    }
    void OnStartScoreGet(GetLeaderboardAroundPlayerResult result){
        foreach (var item in result.Leaderboard){
            score = item.StatValue;
        }
    }

    public void getProgress(){
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result){
        Debug.Log("Received!!");
        if(result.Data != null && result.Data.ContainsKey("level")){
            level = Int32.Parse(result.Data["level"].Value);
        }
        Debug.Log(level);
        OpenScene(level);
    }

    void OnError(PlayFabError error){
        // ErrorMessage.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
        // Invoke("DisableText", 5f);
    }

}
