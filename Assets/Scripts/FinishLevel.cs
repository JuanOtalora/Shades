using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            AnalyticsResult deaths = Analytics.CustomEvent(
                "LevelFinish",
                new Dictionary<string, object>
                {
                    {"Level", SceneManager.GetActiveScene().name},
                    {"Position", transform.position}
                }
                );
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")) {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            AnalyticsResult deaths = Analytics.CustomEvent(
                "LevelFinish",
                new Dictionary<string, object>
                {
                    {"Level", SceneManager.GetActiveScene().name},
                    {"Position", transform.position}
                }
                );
            SceneManager.LoadScene(nextSceneLoad);
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")) {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }


}
