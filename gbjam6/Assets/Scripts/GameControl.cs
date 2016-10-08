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
    private float ballSpawnTimer;
    

	void Start ()
    {
        PlayerAlive = true;
        ballPointSpawns = FindObjectsOfType<BallSpawnPoint>();
        InitialSpawn();
        StartCoroutine("DelayStart");
        ballSpawnTimer = 0;
    }

	void Update ()
    {
        if (PlayerAlive)
        {
            timer += Time.deltaTime;
            TimerText.text = Mathf.Round(timer).ToString();
            if(ballSpawnTimer <= 4)
            {
                ballSpawnTimer += Time.deltaTime;
            }
            else
            {
                InstantiateBall();
                ballSpawnTimer = 0;
            }
        }
	
	}

    void StartGame()
    {
        InitialSpawn();
        StartCoroutine("DelayStart");
    }

    void InitialSpawn()
    {
        GameObject player = Instantiate(Player, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;
    }

    void InstantiateBall()
    {
        GameObject ballClone = Instantiate(Ball, ballPointSpawns[Random.Range(0, ballPointSpawns.Length)].transform.position, Quaternion.identity) as GameObject;
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(2);
        InstantiateBall();
    }

    public IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(1);
    }
}
