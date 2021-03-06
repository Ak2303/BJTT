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
    private AudioSource victorySound;
    public AudioSource bgSound;
    private int isPlaying = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(isPlaying == 0){
            isPlaying = 1;
            victorySound.Play();
            bgSound.Stop();
        }
        Debug.Log("Collision Detected");
        finalScore.stopTimer = false;
        score = (int)finalScore.final_score;
        ScoreText.text = "Score : " + score;
        TotalScoreCanvas.SetActive(true);
        playFabManager.SendLeaderboard(score);
        int curr = SceneManager.GetActiveScene().buildIndex;
        playFabManager.saveProgress((curr - 3).ToString());
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
        victorySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
