using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public GameObject mainPlayer;
    public GameObject shadowPlayer;
    private bool bothControlled;
    // Start is called before the first frame update

    void Start()
    {
        bothControlled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && bothControlled)
        {
            Debug.Log("entra");
            mainPlayer.GetComponent<PlayerController>().enabled = false;
            bothControlled = false;
        }else if (Input.GetKeyDown(KeyCode.S) && !bothControlled)
        {
            mainPlayer.GetComponent<PlayerController>().enabled = true;
            bothControlled = true;
        }
    }
}
