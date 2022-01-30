using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointDecreasedPerSecond;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        scoreAmount=500f;
        pointDecreasedPerSecond=-1f;
        counter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // scoreText.text="Score: "+(int)scoreAmount;
        // scoreAmount+=pointDecreasedPerSecond*Time.deltaTime;
        if(counter < 1 && counter > 0){
            scoreText.text = "!!START!!";
            counter = counter - Time.deltaTime;
        }
        else if(counter < 0){
            scoreText.text="Score: "+(int)scoreAmount;
            scoreAmount+=pointDecreasedPerSecond*Time.deltaTime;
        }else{
            string count = counter.ToString("0");
            scoreText.text = count;
            counter = counter - Time.deltaTime;
        }
    }
}
