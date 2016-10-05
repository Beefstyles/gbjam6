using UnityEngine;
using System.Collections;

public class PaddleAI : MonoBehaviour {

    public Transform Ball;
    private float speed = 0.1F;
    private float initialX, initialY, initialZ;
    public float MinX, MaxX, MinY, MaxY;
    public bool isHorizontalMovement;
    private bool targetAcquired;
    
	// Use this for initialization
	void Start () {
        
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        Ball = GameObject.FindGameObjectWithTag("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (targetAcquired)
        {
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
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialX, Ball.position.x, initialZ), step);
                }
            }
            
        }
        
        
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Ball = GameObject.FindGameObjectWithTag("Ball").transform;
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
