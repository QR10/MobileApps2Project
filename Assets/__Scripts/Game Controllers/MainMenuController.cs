using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Load Gameplay scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
