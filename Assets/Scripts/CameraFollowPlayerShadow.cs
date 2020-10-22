using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerShadow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerShadow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerShadow.transform.position.x, -16, -10);
    }
}
