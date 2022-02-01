using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour
{
    public float xp;
    public float final_score;
    public Score score;
    public bool stopTimer = true;
    // Start is called before the first frame update
    
    void Start()
    {
        xp=200;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTimer){
            final_score=xp+score.scoreAmount;
            //Debug.Log(final_score);
        }
    }
}
