using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject scoreCanvas;
    public LifeScript life;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Finish"){
            Debug.Log("Collision Detected");
            scoreCanvas.SetActive(true); 
        }
        else{
             Debug.Log("Collision Detected");
            life.jaan--;
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
