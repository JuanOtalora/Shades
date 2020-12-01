using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public GameObject respawnPrefab;
    public GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Ladder");

        foreach (GameObject respawn in respawns)
        {
            Debug.Log(respawn.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
