using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void NextScene()
    {
        if (scene.name == "Game1")
        {
            SceneManager.LoadScene("Game2");
        }
        else if (scene.name == "Game2")
        {
            SceneManager.LoadScene("Game3");
        }
    }

    public void PreviousScene()
    {
        if (scene.name == "Game2")
        {
            SceneManager.LoadScene("Game1");
        }
        else if (scene.name == "Game3")
        {
            SceneManager.LoadScene("Game2");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
