using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int gamelevel;
    public Button[] lvlbuttons;
    public Sprite lockpix;

    public void PlayLevel()
    {
        if (gamelevel == 1)
        {
            SceneManager.LoadScene("FirstLevel");
        }else if (gamelevel == 2)
        {
            SceneManager.LoadScene("Level2New");
        }else if (gamelevel == 3)
        {
            SceneManager.LoadScene("Level4");

        }
        else if (gamelevel == 4)
        {
            SceneManager.LoadScene("Level5");

        }
        else if (gamelevel == 5)
        {
            SceneManager.LoadScene("Level3New");

        }
    }

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        for (int i = 0; i < lvlbuttons.Length; i++)
        {
            if (i+2> levelAt)
            {
                lvlbuttons[i].interactable = false;
                lvlbuttons[i].GetComponent<Image>().sprite = lockpix;
                lvlbuttons[i].GetComponentInChildren<Text>().enabled = false;
            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
