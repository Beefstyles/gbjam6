using UnityEngine;
using System.Collections;

public class BGChanger : MonoBehaviour {

    private GameObject bgSprite;
    private float rotationSpeed;


    void Start()
    {
        rotationSpeed = 10F;
        bgSprite = gameObject;
    }
	void Update ()
    {
        bgSprite.transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed, Space.World);
	}
}
