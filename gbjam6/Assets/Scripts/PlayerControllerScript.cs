using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {


    private float speed = 3.0F;
    private float jumpSpeed = 15.0F;
    Rigidbody2D rb;

    private bool isGrounded;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
        if (isGrounded)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Fire");
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Entered ground");
        if(coll.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Exited ground");
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
