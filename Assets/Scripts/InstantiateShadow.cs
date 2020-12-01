using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateShadow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainPlayer;
    float distance;
    float maxDistance = 1.0f;
    private int instantiate;
    public GameObject killZone;

    public GameObject shadow;

    void Start()
    {
        instantiate = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(mainPlayer.transform.position, this.transform.position);
        if (distance <= maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.L) && instantiate == 0)
            {
                Destroy(killZone);
                Instantiate(shadow, new Vector3(64.6f, -16.84f, 0), Quaternion.identity);
                instantiate++;
            }
        }
    }

    
}
