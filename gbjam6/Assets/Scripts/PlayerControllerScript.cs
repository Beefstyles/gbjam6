using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {


    private float speed = 3.0F;
    private float jumpSpeed = 15.0F;
    private float pogoForce = 30F;
    Rigidbody2D rb;

    private bool isGrounded;
    private bool pogoUsed;

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
                rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
            }
        }

        if (!isGrounded && Input.GetButton("Fire2"))
        {
            pogoUsed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (pogoUsed)
        {
            rb.AddForce(Vector2.up * pogoForce);
            pogoUsed = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
