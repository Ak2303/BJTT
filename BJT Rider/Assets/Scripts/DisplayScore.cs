using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    public Final_Score finalScore;
    public GameObject TotalScoreCanvas;
    public int score = 0;
    public PlayFabManager playFabManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        finalScore.stopTimer = false;
        score = (int)finalScore.final_score;
        ScoreText.text = "Score : " + score;
        TotalScoreCanvas.SetActive(true);
        playFabManager.SendLeaderboard(score);
    }

    //Button on the Score UI
    public void OnNext(){
        int curr = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curr+1);
    }

    public void OnExit(){
        SceneManager.LoadScene("HomePage");
    }

    public void OnRestart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
