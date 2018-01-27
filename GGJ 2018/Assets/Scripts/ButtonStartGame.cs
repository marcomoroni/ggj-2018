using UnityEngine;
using System.Collections;

public class ButtonStartGame : MonoBehaviour
{
    public void StartGameButton(int index)
    {
        Application.LoadLevel(1);
    }

    public void StartGameButton(string levelName)
    {
        Application.LoadLevel("Main");
    }
}