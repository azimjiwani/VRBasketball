using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Basketball basketball;
	public Vector3 basketballOffset;
	public float basketballDistance = 1f;
	public float minimumshootingForce = 400;
	public float maximumshootingForce = 1000;
	private bool calculatingShot;
	private float shootingTimer = 0f;

	private bool holdingBasketball;

    // Start is called before the first frame update
    void Start(){
    	holdingBasketball = true;


      }
      public void PickBasketball () {
        shootingTimer = 0f;
        holdingBasketball = true;
        calculatingShot = false;

        basketball.hitSomething = false;
        
    }

    // Update is called once per frame
   	void Update(){
   		if (holdingBasketball) {
   			basketball.transform.position = this.transform.position + this.transform.forward * basketballDistance + basketballOffset;
   			basketball.GetComponent<Rigidbody> () .useGravity = false;

   			if (calculatingShot == false) {
   					shootingTimer += Time.deltaTime; 
   				}

   			if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")){
   				if (calculatingShot == false) {
   					calculatingShot = true; 
   				}
   				else if (holdingBasketball) {
   					holdingBasketball = false;
   					basketball.GetComponent<Rigidbody> () .useGravity = true;
   					float calculatedScale = Mathf.Min(shootingTimer, 1f);
   					float calculatedForce = minimumshootingForce + (maximumshootingForce - minimumshootingForce) * calculatedScale;

   					basketball.GetComponent<Rigidbody> ().AddForce (this.transform.forward * calculatedForce);
   				}
   			}
        }
    }
}
