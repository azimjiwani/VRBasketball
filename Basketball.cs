using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour{

	public bool hitSomething = false;
	public bool gotRightTarget = false;
	public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider collider) {
    	if (hitSomething == false){
    		if (collider.tag == "BasketballTarget"){
    			hitSomething = true;
    			gotRightTarget = true;
    			score++;
    		} else if (collider.tag == "WrongTarget") {
    			hitSomething = true;
    			gotRightTarget = false;

    		}
    	}
    	
    }
}
