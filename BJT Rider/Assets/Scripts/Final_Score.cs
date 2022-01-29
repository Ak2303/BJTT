using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Score : MonoBehaviour
{
    public float xp;
    public float final_score;
    public float scoreAmount;
    // Start is called before the first frame update
    void Start()
    {
        xp=200;
    }

    // Update is called once per frame
    void Update()
    {
        final_score=xp+scoreAmount;
        Debug.Log(final_score);
    }
}
