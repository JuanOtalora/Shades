using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
         
    }

    public void RestartGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LevelSelector()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelector");
    }
}
