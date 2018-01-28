using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public GameObject p1Text;
    public GameObject p2Text;

    public GameObject timeText;
    public GameObject winText;

    public PlayerMvm p1S;
    public PlayerMvm p2S;

    public List<string> Teams = new List<string>
    {
        "None",
        "Anger",
        "Love",
        "Madness",
        "Happiness",
        "Sadness",
    };

    public List<EmotionUnit> allUnits;

    public float clock = 120f;

    public bool winnerDeclared = false;
    public bool draw = false;
    public int winner = 0;

	// Use this for initialization
	void Start ()
    {
        winnerDeclared = false;
        allUnits = new List<EmotionUnit>();

        SpawnPlayers();
	}
	
	// Update is called once per frame
	void Update ()
    {
        clock -= Time.deltaTime;

        if (winnerDeclared)
        {
            if (Input.GetButtonDown("X") || Input.GetButtonDown("X_2"))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (clock <= 0f)
        {
            winnerDeclared = true;

            if (p1S.EmotionArmy.Count > p2S.EmotionArmy.Count)
            {
                winner = 1;
            }
            else if (p1S.EmotionArmy.Count == p2S.EmotionArmy.Count)
            {
                draw = true;
            }
            else
            {
                winner = 2;
            }
        }
        else
        {
            if (p1S.EmotionArmy.Count <= 0)
            {
                winnerDeclared = true;
                winner = 2;
            }
            else if (p2S.EmotionArmy.Count <= 0)
            {
                winnerDeclared = true;
                winner = 1;
            }
        }

        if (winnerDeclared)
        {
            winText.SetActive(true);

            if (draw)
            {
                winText.GetComponent<Text>().color = Color.white;
                winText.GetComponent<Text>().text = "Draw!\nNo one wins!\nAhahahaha!\nPress X";
            }
            else
            {
                if (winner == 1)
                {
                    winText.GetComponent<Text>().color = p1S.color;
                    winText.GetComponent<Text>().text = "P1 (" + p1S.Team + ") wins!\nCongratulations!\nPress X";
                }
                else
                {
                    winText.GetComponent<Text>().color = p1S.color;
                    winText.GetComponent<Text>().text = "P1 (" + p2S.Team + ") wins!\nCongratulations!\nPress X";
                }
            }
        }

        timeText.GetComponent<Text>().text = "Time Left\n" + clock;
        p1Text.GetComponent<Text>().text = "P1 Units\n" + p1S.EmotionArmy.Count;
        p2Text.GetComponent<Text>().text = "P2 Units\n" + p2S.EmotionArmy.Count;

        p1Text.GetComponent<Text>().color = p1S.color;
        p2Text.GetComponent<Text>().color = p2S.color;
    }

    private void SpawnPlayers()
    {
        GameObject p1 = Instantiate(PlayerPrefab, new Vector3(-8f, -8f), Quaternion.identity);
        p1.GetComponent<PlayerMvm>().ManagerScript = GetComponent<GameManagerScript>();
        p1.GetComponent<PlayerMvm>().Team = Teams[Random.Range(1, 6)];
        p1.GetComponent<PlayerMvm>().player_no = 1;
        p1S = p1.GetComponent<PlayerMvm>();

        GameObject p2 = Instantiate(PlayerPrefab, new Vector3(8f, 8f), Quaternion.identity);
        p2.GetComponent<PlayerMvm>().ManagerScript = GetComponent<GameManagerScript>();

        string team = Teams[Random.Range(1, 6)];

        while(team == p1.GetComponent<PlayerMvm>().Team)
        {
            team = Teams[Random.Range(1, 6)];
        }
        p2.GetComponent<PlayerMvm>().Team = team;
        p2.GetComponent<PlayerMvm>().player_no = 2;
        p2S = p2.GetComponent<PlayerMvm>();
    }
}
