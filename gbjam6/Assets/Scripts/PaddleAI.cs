using UnityEngine;
using System.Collections;

public class PaddleAI : MonoBehaviour {

    public Transform Ball;
    private float speed = 5;
    
    
	// Use this for initialization
	void Start () {
        Ball = GameObject.FindGameObjectWithTag("Ball").transform;
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Ball.position, step);
	}
}
