using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            Destroy(coll.gameObject);
        }
    }
}
