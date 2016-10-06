using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public GameObject Ball;
    public GameObject Player;
    public Transform PlayerSpawnLocation;
    public Text TimerText;
    public float timer = 0F;
    public bool PlayerAlive;

	void Start ()
    {
        PlayerAlive = true;

    }

	void Update ()
    {
        if (PlayerAlive)
        {
            timer += Time.deltaTime;
            TimerText.text = timer.ToString();
        }
	
	}

    void StartGame()
    {

    }
    void InitialSpawn()
    {
        GameObject player = Instantiate(Player, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;
    }
}
