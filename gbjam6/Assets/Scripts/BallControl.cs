using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    public Vector3 dir;
    Rigidbody2D rb;

	void Start ()
    {
        float xDir = Random.Range(-1F, 1F);
        float yDir = Random.Range(-1F, 1F);
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector3(xDir, yDir, 0F);
        dir = dir.normalized;
        rb.velocity = dir * 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
