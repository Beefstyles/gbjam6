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
    
	// Use this for initialization
	void Start () {
        Ball = null;
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        resetTimer = 0F;
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (targetAcquired)
        {
            testPos = Ball.transform.position;
            if (isHorizontalMovement)
            {
                if(Ball.position.x <= MaxX && Ball.position.x >= MinX)
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

        else if (!targetAcquired)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialX, initialY, initialZ),step);
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
            
            targetAcquired = true;
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
}
