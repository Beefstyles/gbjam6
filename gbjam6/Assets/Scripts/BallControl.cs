using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    public Vector3 dir;
    Rigidbody2D rb;
    GameControl gameControl;
    Rigidbody2D collRb;

	void Start ()
    {
        gameControl = FindObjectOfType<GameControl>();
        RandomDirection();
	}
	
	void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case ("Player"):
                StartCoroutine(gameControl.StartDeath());
                //Destroy(gameObject);
                break;
            case ("PogoPoint"):
                collRb = coll.GetComponentInParent<Rigidbody2D>();
                collRb.AddForce(Vector2.up * 5);
                Destroy(gameObject);        
                break;
        }
    }

    void RandomDirection()
    {
        float xDir = Random.Range(-1F, 1F);
        float yDir = Random.Range(-1F, 1F);
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector3(xDir, yDir, 0F);
        dir = dir.normalized;
        rb.velocity = dir * 3;
    }
    
}
