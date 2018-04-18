using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighteningObject : MonoBehaviour
{
    public bool destroy = false;
    public int damage = 1;
    public float speed = 2f;
    public AudioClip crack;
    private bool reverse;
    private bool startMoving;
    private GameControl gameControl;
    private PlayControl playControl;
    // Use this for initialization
    void Start()
    {
        playControl = GameControl.FindObjectOfType<PlayControl>();
        gameControl = GameObject.FindObjectOfType<GameControl>();
        reverse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playControl.transform.position.x >= 3 && playControl.transform.position.x <= 10)
        {
            startMoving = true;
        }
        if (!gameControl.gameOver && !gameControl.gameEnd && !reverse && startMoving)
        {
            float distance = speed * Time.deltaTime;
            transform.position += new Vector3(0, -distance);
        }
        if (!gameControl.gameOver && !gameControl.gameEnd && reverse && startMoving)
        {
            float distance = speed * Time.deltaTime;
            transform.position += new Vector3(0, distance);
        }

        if (transform.position.y <= 6)
        {
            reverse = true;
        }
        if (transform.position.y >= 15)
        {
            reverse = false;
            startMoving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
    }


    void OnParticleCollision(GameObject other)
    {
        //        Rigidbody body = other.GetComponent<Rigidbody>();
        //        if (body) {
        //            Vector3 direction = other.transform.position - transform.position;
        //            direction = direction.normalized;
        //            body.AddForce(direction * 5);
        //        }
        //
        { if (other.transform.tag == "Player") { Debug.Log("Damage"); } }
    }
}
