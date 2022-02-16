using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public Image healthBar;
    public AudioSource gameoverSound;
    public AudioSource bgSound;
    public int jaan = 4;
    private float decrement = 0.25F;//
    public GameObject ScoreCanvas;
    private int isPlaying = 0;
    // Start is called before the first frame update
    void Start()
    {
        //gameoverSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = jaan * decrement;
        if(jaan==0){
            if(isPlaying == 0){
                gameoverSound.Play();
                bgSound.Stop();
                isPlaying = 1;
            }
            
            ScoreCanvas.SetActive(true);
        }
    }
}
