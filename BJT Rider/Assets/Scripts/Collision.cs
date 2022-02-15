using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject scoreCanvas;
    public GameObject gameCanvas;
    public LifeScript life;
    public Score scoreScript;

    public AudioSource achievementSound;
    public AudioSource collideSound;
    public AudioSource warningSound;
    private int isPlaying = 0;
    private void OnTriggerEnter(Collider other)
    {
                
        if(this.gameObject.CompareTag("fence")){
            Debug.Log(this.gameObject.tag);
            scoreScript.pointDecreasedPerSecond = 0f;
            gameCanvas.SetActive(false); 
            scoreCanvas.SetActive(true);
        }else if(this.gameObject.CompareTag("WrongPath")){
            if(isPlaying == 0){
                warningSound.Play();
                isPlaying = 1;
            }
            Debug.Log(this.gameObject.tag);
            scoreScript.pointDecreasedPerSecond = -5f;
        }else if(this.gameObject.CompareTag("CorrectPath")){
            warningSound.Stop();
            isPlaying = 0;
            Debug.Log(this.gameObject.tag);
            scoreScript.pointDecreasedPerSecond = -1f;
        }else if(this.gameObject.CompareTag("Passed")){
            achievementSound.Play();

            Debug.Log(this.gameObject.tag);
            scoreScript.scoreAmount += 50;
        }
        else{
            collideSound.Play();
            Debug.Log(this.gameObject.tag);
            life.jaan--;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // achievementSound = GetComponent<AudioSource>();
        // collideSound = GetComponent<AudioSource>();
        // warningSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
