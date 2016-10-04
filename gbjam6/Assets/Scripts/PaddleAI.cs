using UnityEngine;
using System.Collections;

public class PaddleAI : MonoBehaviour {

    public Transform Ball;
    private float speed = 0.1F;
    private float initialX, initialY, initialZ;
 
    
    
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Ball.position.x, initialY, initialZ), step);
	}
}
