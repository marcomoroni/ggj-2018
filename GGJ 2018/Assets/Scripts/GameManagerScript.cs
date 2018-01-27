using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public List<string> Teams = new List<string>
    {
        "None",
        "Anger",
        "Love",
        "Madness",
        "Happiness",
        "Sadness",
    };

    public int[] UnitCounts = new int[5] { 0, 0, 0, 0, 0 };

    public List<EmotionUnit> allUnits;

    public float clock = 120f;

    public bool winnerDeclared = false;
    public bool draw = false;
    public string winningTeam;

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

        if (clock <= 0f)
        {
            winnerDeclared = true;

            int[] counts = new int[5] { 0, 0, 0, 0, 0 };

            for (int i = 0; i < allUnits.Count; i++)
            {
                switch (allUnits[i].npcScript.Team)
                {
                    case "Anger":
                        counts[0]++;
                        break;
                    case "Love":
                        counts[1]++;
                        break;
                    case "Madness":
                        counts[2]++;
                        break;
                    case "Happiness":
                        counts[3]++;
                        break;
                    case "Sadness":
                        counts[4]++;
                        break;
                }
            }

            int best = 0;
            int idx = 0;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > best)
                {
                    best = counts[i];
                    draw = false;
                    idx = i;
                }
                else if (counts[i] == best)
                {
                    draw = true;
                }
            }
        }

        int c = 0;
        for (int i = 0; i < allUnits.Count; i++)
        {
            switch(allUnits[i].npcScript.Team)
            {
                case "Anger":
                    UnitCounts[0]++;
                    break;
                case "Love":
                    UnitCounts[1]++;
                    break;
                case "Madness":
                    UnitCounts[2]++;
                    break;
                case "Happiness":
                    UnitCounts[3]++;
                    break;
                case "Sadness":
                    UnitCounts[4]++;
                    break;
            }
        }

        for (int i = 0; i < UnitCounts.Length; i++)
        {
            if (UnitCounts[i] >= allUnits.Count)
            {
                winnerDeclared = true;
                winningTeam = Teams[i];
                break;
            }
        }
	}

    private void SpawnPlayers()
    {
        GameObject p1 = Instantiate(PlayerPrefab, new Vector3(-4f, -4f), Quaternion.identity);
        p1.GetComponent<PlayerMvm>().ManagerScript = this;
        p1.GetComponent<PlayerMvm>().Team = Teams[Random.Range(1, 5)];

        GameObject p2 = Instantiate(PlayerPrefab, new Vector3(4f, 4f), Quaternion.identity);
        p2.GetComponent<PlayerMvm>().ManagerScript = this;

        string team = Teams[Random.Range(1, 5)];

        while(team == p1.GetComponent<PlayerMvm>().Team)
        {
            team = Teams[Random.Range(1, 5)];
        }
        p2.GetComponent<PlayerMvm>().Team = team;
    }
}
