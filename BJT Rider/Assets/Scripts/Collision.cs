using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject scoreCanvas;
    public LifeScript life;
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.CompareTag("Finish")){
            Debug.Log(this.gameObject.tag);
            scoreCanvas.SetActive(true); 
        }
        else{
            if(this.gameObject.CompareTag("Respawn")){
                Debug.Log(this.gameObject.tag);
                scoreCanvas.SetActive(true); 
            }
            else{
                Debug.Log(this.gameObject.tag);
                life.jaan--;
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
