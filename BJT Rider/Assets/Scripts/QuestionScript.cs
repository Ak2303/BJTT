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
    public LifeScript lifeScript;
    public void OnFirstOption(){
        if(correctAnswer == 1){
            doorsLeft.transform.Rotate(0,-90,0);
            doorsRight.transform.Rotate(0,-90,0);
            doorsLeft.GetComponent<BoxCollider>().enabled = false;
            doorsRight.GetComponent<BoxCollider>().enabled = false;
            questionCanvas.SetActive(false);
        }else{
            Verdict.text="Wrong Option!! You lost one life. Try again.";
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
            questionCanvas.SetActive(false);
        }else{
            Verdict.text="Wrong Option!! You lost one life. Try again.";
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
            questionCanvas.SetActive(false);
        }else{
            Verdict.text="Wrong Option!! You lost one life. Try again.";
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
