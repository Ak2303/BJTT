using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private float counter;
    float t;
    

    void Start(){
        startTime = 300;
        t = startTime;
        counter = 3;
    }

    void Update(){
        if(counter < 1 && counter > 0){
            timerText.text = "!!START!!";
            
            counter = counter - Time.deltaTime;
        }else if(counter < 0){
            t = t - Time.deltaTime;
            string minutes = ((int)t/60).ToString();
            string seconds = (t % 60).ToString("0.00");
            timerText.text = minutes + ":" + seconds;
        }else{
            string count = counter.ToString("0");
            timerText.text = count;
            counter = counter - Time.deltaTime;
        }
    }
}
