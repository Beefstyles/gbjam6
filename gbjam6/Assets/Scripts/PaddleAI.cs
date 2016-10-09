using UnityEngine;
using System.Collections;

public class PaddleAI : MonoBehaviour {

    public Transform Ball;
    private float speed = 7F;
    private float initialX, initialY, initialZ;
    public float MinX, MaxX, MinY, MaxY;
    public bool isHorizontalMovement;
    public bool targetAcquired;
    public Vector3 testPos;
    private float resetTimer;
    private AudioSource paddleHit;
    
	void Start () {
        Ball = null;
        paddleHit = GetComponent<AudioSource>();
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        resetTimer = 0F;
    }

	void Update () {
        float step = speed * Time.deltaTime;
        if (targetAcquired)
        {
            if (Ball != null)
            {
                testPos = Ball.transform.position;

                if (isHorizontalMovement)
                {
                    if (Ball.position.x <= MaxX && Ball.position.x >= MinX)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Ball.position.x, initialY, initialZ), step);
                    }
                }

                else
                {
                    if (Ball.position.y <= MaxY && Ball.position.y >= MinY)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialX, Ball.position.y, initialZ), step);
                    }
                }
            }
        }

        else if (!targetAcquired)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialX, initialY, initialZ),step);
        }

        if (resetTimer >= 2F)
        {
            resetTimer -= Time.deltaTime;
        }
        else if (resetTimer <= 0F)
        {
            targetAcquired = false;
            Ball = null;
            resetTimer = 2F;
        }
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            if(Ball == null)
            {
                Ball = GameObject.FindGameObjectWithTag("Ball").transform;
            }

            if (!targetAcquired)
            {
                targetAcquired = true;
            }
           
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            targetAcquired = false;
            Ball = null;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            paddleHit.Play();
        }
    }
}
