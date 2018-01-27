using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

    private Text highScoreText;

	// Use this for initialization
	void Start () {
        highScoreText = GetComponent<Text>();
        highScoreText.text = PlayerPrefs.GetInt("High Score").ToString();
    }

}
