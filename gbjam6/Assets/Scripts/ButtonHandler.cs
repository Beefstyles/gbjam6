using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
