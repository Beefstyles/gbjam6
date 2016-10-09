using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public GameObject Ball;
    public GameObject Player;
    public Transform PlayerSpawnLocation;
    public Text TimerText, FinalScoreText, HighScoreText;
    public float timer = 0F;
    public bool PlayerAlive;
    private BallSpawnPoint[] ballPointSpawns;
    private float ballSpawnTimer;
    private float ballSpawnTimerMax;
    public GameObject GameOnScreen, GameOverScreen;
    private GameObject player;
    

	void Start ()
    {
        Time.timeScale = 1F;
        GameOnScreen.SetActive(true);
        GameOverScreen.SetActive(false);
        PlayerAlive = true;
        ballPointSpawns = FindObjectsOfType<BallSpawnPoint>();
        InitialSpawn();
        StartCoroutine("DelayStart");
        ballSpawnTimer = 0;
        ballSpawnTimerMax = 7;
    }

	void Update ()
    {
        if (PlayerAlive)
        {
            timer += Time.deltaTime;
            TimerText.text = Mathf.Round(timer).ToString();
            if(ballSpawnTimer <= ballSpawnTimerMax)
            {
                ballSpawnTimer += Time.deltaTime;
            }
            else
            {
                InstantiateBall();
                if(ballSpawnTimerMax>= 2)
                {
                    ballSpawnTimerMax = ballSpawnTimerMax - 0.25F;
                }

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
        player = Instantiate(Player, PlayerSpawnLocation.position, Quaternion.identity) as GameObject;
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
        yield return new WaitForSeconds(.1F);
        Destroy(player);
        GameOnScreen.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0F;
        FinalScoreText.text = Mathf.RoundToInt(timer).ToString();
        if(CarryOverInfo.HighScore <= timer)
        {
            CarryOverInfo.HighScore = Mathf.RoundToInt(timer);
        }
        HighScoreText.text = CarryOverInfo.HighScore.ToString();
    }
}
