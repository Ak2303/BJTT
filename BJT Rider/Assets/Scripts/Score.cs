using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointDecreasedPerSecond = -1f;
    public float counter;
    public AudioSource bgSound;
    public AudioSource gameoverSound;
    private int isPlaying = 0;
    private int isPlaying2 = 0;
    public GameObject ScoreCanvas;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount=500f;
        pointDecreasedPerSecond = -1f;
        counter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // scoreText.text="Score: "+(int)scoreAmount;
        // scoreAmount+=pointDecreasedPerSecond*Time.deltaTime;
        if(counter < 1 && counter > 0){
            scoreText.text = "!!START!!";
            if(isPlaying == 0){
                bgSound.Play();
                isPlaying = 1;
            }
            counter = counter - Time.deltaTime;
        }
        else if(counter < 0){
            scoreText.text="Score: "+(int)scoreAmount;
            scoreAmount+=pointDecreasedPerSecond*Time.deltaTime;
            if(scoreAmount <=0){
                if(isPlaying2 == 0){
                    gameoverSound.Play();
                    bgSound.Stop();
                    isPlaying2 = 1;
                }
                ScoreCanvas.SetActive(true);
            }
        }else{
            string count = counter.ToString("0");
            scoreText.text = count;
            counter = counter - Time.deltaTime;
        }
    }
}
