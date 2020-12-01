using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject shadowPlayer;
    public GameObject marker1;
    public GameObject marker2;

    private bool bothControlled;
    private bool controlledOne;

    // Start is called before the first frame update

    void Start()
    {
        bothControlled = true;
        controlledOne = false;
        marker1.SetActive(false);
        marker2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && bothControlled)
        {
            Debug.Log("entra");
            mainPlayer.GetComponent<PlayerController>().enabled = false;
            controlledOne = true;
            bothControlled = false;
            marker2.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.S) && !bothControlled && controlledOne)
        {
            mainPlayer.GetComponent<PlayerController>().enabled = true;
            shadowPlayer.GetComponent<ShadowController>().enabled = false;
            controlledOne = false;
            bothControlled = false;
            marker2.SetActive(false);
            marker1.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.S) && !bothControlled && !controlledOne)
        {
            mainPlayer.GetComponent<PlayerController>().enabled = true;
            shadowPlayer.GetComponent<ShadowController>().enabled = true;
            bothControlled = true;
            marker1.SetActive(false);
            marker2.SetActive(false);


        }
    }
}
