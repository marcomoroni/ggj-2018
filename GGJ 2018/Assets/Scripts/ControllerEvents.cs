using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerEvents : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Play();
        Quit();
	}

    public void Play()
    {
        if (Input.GetButtonDown("X") || Input.GetButtonDown("X_2"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Quit()
    {
        if (Input.GetButtonDown("Select1") || Input.GetButtonDown("Select2"))
        {
            print("Quit");
            Application.Quit();
        }
    }
}
