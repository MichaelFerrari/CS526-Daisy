using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour {
	public bool isComputer;
	private float padding = 1f;
	private float xmin;
	private float xmax;
	private Rigidbody2D rigi;
	private GameControl gameControl;

	private Vector3 fp;   //First touch position
	private Vector3 lp;   //Last touch position
	private float dragDistance;  //minimum distance for a swipe to be registered

	public static MovingObject movingObject = null;

	public ParticleSystem healParticle;
//    public ParticleSystem healTargted; //UNDER RESOURCES FOLDER AS A PREFAB AS "Heal"

	public ParticleSystem hurtParticle;
//	public ParticleSystem hurtTargted;

	// Use this for initialization
	void Start () {
//		isComputer = true;
		gameControl = GameObject.FindObjectOfType<GameControl> ();
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1, 0, distance));

		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;

		rigi = GetComponent<Rigidbody2D> ();

		dragDistance = Screen.width * 5 / 100; //dragDistance is 15% height of the screen

//		ParticleSystem heal = GetComponent<ParticleSystem>(); 
//		heal.Stop();
		healParticle.Stop();
		hurtParticle.Stop();
	}

	// Update is called once per frame
	void Update () {
		if (!gameControl.gameOver) {
			//if (Input.GetMouseButtonDown(0)) {
			//	rigi.AddForce (new Vector2 (0, gameControl.playerForce));
			//}

			//if (Input.GetTouch(0).position.x < Screen.width/2) {
			//	rigi.velocity = new Vector2 (-gameControl.playerSpeed, 0);
			//} else if (Input.GetTouch(0).position.x > Screen.width/2) {
			//	rigi.velocity = new Vector2 (gameControl.playerSpeed, 0);
			//}
			if (!isComputer) {
				if (Input.touchCount == 1) {
					Touch touch = Input.GetTouch(0); // get the touch
					if (touch.position.x < Screen.width/2) {
						if (touch.phase == TouchPhase.Began) {
				          fp = touch.position;
				          lp = touch.position;
		        }
		        else if (touch.phase == TouchPhase.Moved) {
		          lp = touch.position;
		        }
		        else if (touch.phase == TouchPhase.Ended) {
		          lp = touch.position;
		        }
	 
		        if (Mathf.Abs(lp.x - fp.x) > dragDistance) {
		          if ((lp.x > fp.x)) {   //Right swipe
		          	rigi.velocity = new Vector2 (gameControl.playerSpeed, 0);
		          	Debug.Log("Right Swipe");
		          }
		          else {   //Left swipe
		          	rigi.velocity = new Vector2 (-gameControl.playerSpeed, 0);
		            Debug.Log("Left Swipe");
		          }
	        	}
	        }
	      }
	     	if (Input.GetMouseButton(0)) {
				rigi.AddForce (new Vector2 (0, gameControl.playerForce));
	      }
	    }
	    else {
	    	if (Input.GetKey (KeyCode.UpArrow)) {
	    		rigi.AddForce (new Vector2 (0, gameControl.playerForce));
        	}
 
			if (Input.GetKeyDown (KeyCode.A)) {
				rigi.velocity = new Vector2 (-gameControl.playerSpeed, 0);
			} else if (Input.GetKeyDown (KeyCode.D)) {
				rigi.velocity = new Vector2 (gameControl.playerSpeed, 0);
			}
	    }
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (gameControl.gameOver) {
			gameControl.goToLose ();
		}
	}

//	void OnTriggerEnter2D(Collider2D collider) {
//		MovingObject movingObject = collider.gameObject.GetComponent<MovingObject>();
//		if (movingObject != null) {
//			int count = movingObject.damage;
//			if (count < 0) {
//				gameControl.AddHealth (count);
//			} else {
//				gameControl.Hurt (count);
//			}
//			if (movingObject.destroy) {
//				Destroy (collider.gameObject);
//			}
//		}		
//	}
	void OnTriggerEnter2D(Collider2D collider) {
		if (movingObject == null) {
			movingObject = collider.gameObject.GetComponent<MovingObject> ();
			if (movingObject != null) {
				int count = movingObject.damage;
				if (count < 0) {
//					ParticleSystem heal = GetComponent<ParticleSystem>(); 
//					heal.Play();
					healParticle.Play();
					gameControl.AddHealth (count);
					//Instantiate(coinparticle, collider.transform.position, Quaternion.identity);


				} else {
					gameControl.Hurt (count);
					hurtParticle.Play();
				}
				if (movingObject.destroy) {
					Destroy (collider.gameObject);

				}
			}		
		}
	}
}
