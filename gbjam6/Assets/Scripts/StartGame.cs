using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1")|| Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(1);
        }
	}
}
