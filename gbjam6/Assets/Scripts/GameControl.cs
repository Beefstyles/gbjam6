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
    private BallSpawnPoint[] ballPointSpawns;

	void Start ()
    {
        PlayerAlive = true;
        ballPointSpawns = FindObjectsOfType<BallSpawnPoint>();
    }

	void Update ()
    {
        if (PlayerAlive)
        {
            timer += Time.deltaTime;
            TimerText.text = Mathf.Round(timer).ToString();
        }
	
	}

    void StartGame()
    {

    }
    void InitialSpawn()
    {
        GameObject player = Instantiate(Player, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;
    }

    void InstantiateBall()
    {
        GameObject ballClone = Instantiate(Ball, ballPointSpawns[Random.Range(0, ballPointSpawns.Length)].transform.position, Quaternion.identity) as GameObject;
    }
}
