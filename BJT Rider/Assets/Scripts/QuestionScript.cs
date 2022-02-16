using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    public Text Verdict;
    public int correctAnswer = 1;
    
    public GameObject doorsLeft;
    public GameObject doorsRight;
    public GameObject questionCanvas;
    public GameObject gameCanvas;
    public LifeScript lifeScript;
    public Score scoreScript;
    private AudioSource healthgainedSound;
    public AudioSource wrongAnswerSound;
    public void OnFirstOption(){
        if(correctAnswer == 1){
            doorsLeft.transform.Rotate(0,-90,0);
            doorsRight.transform.Rotate(0,-90,0);
            doorsLeft.GetComponent<BoxCollider>().enabled = false;
            doorsRight.GetComponent<BoxCollider>().enabled = false;
            scoreScript.pointDecreasedPerSecond = -1f;
            if(lifeScript.jaan<4){
                lifeScript.jaan++;
                healthgainedSound.Play();
            }
            questionCanvas.SetActive(false);
            gameCanvas.SetActive(true); 

        }else{
            wrongAnswerSound.Play();
            Verdict.text="Wrong Option!! You lost one life. Try again.";
            Invoke("DisableText", 1f);
            Debug.Log("WrongAnswer");
            lifeScript.jaan = lifeScript.jaan - 1;
            if(lifeScript.jaan == 0){
                Debug.Log("Game Over");
            } 

        }
    }

    public void OnSecondOption(){
        if(correctAnswer == 2){
            doorsLeft.transform.Rotate(0,-90,0);
            doorsRight.transform.Rotate(0,-90,0);
            doorsLeft.GetComponent<BoxCollider>().enabled = false;
            doorsRight.GetComponent<BoxCollider>().enabled = false;
            if(lifeScript.jaan<4){
                lifeScript.jaan++;
                healthgainedSound.Play();
            }
            questionCanvas.SetActive(false);
            scoreScript.pointDecreasedPerSecond = -1f;
            gameCanvas.SetActive(true); 
        }else{
            wrongAnswerSound.Play();
            Verdict.text="Wrong Option!! You lost one life. Try again.";
            Invoke("DisableText", 1f);
            Debug.Log("WrongAnswer");
            lifeScript.jaan = lifeScript.jaan - 1;
            if(lifeScript.jaan == 0){
                Debug.Log("Game Over");
            }
        }
    }

    public void OnThirdOption(){
        if(correctAnswer == 3){
            doorsLeft.transform.Rotate(0,-90,0);
            doorsRight.transform.Rotate(0,-90,0);
            doorsLeft.GetComponent<BoxCollider>().enabled = false;
            doorsRight.GetComponent<BoxCollider>().enabled = false;
            if(lifeScript.jaan<4){
                lifeScript.jaan++;
                healthgainedSound.Play();
            }
            questionCanvas.SetActive(false);
            scoreScript.pointDecreasedPerSecond = -1f;
            gameCanvas.SetActive(true); 
        }else{
            wrongAnswerSound.Play();
            Verdict.text="Wrong Option!! You lost one life. Try again.";
            Invoke("DisableText", 1f);
            Debug.Log("WrongAnswer");
            lifeScript.jaan = lifeScript.jaan - 1;
            if(lifeScript.jaan == 0){
                Debug.Log("Game Over");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        healthgainedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisableText()
   { 
      Verdict.text = ""; 
   }
}
