using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D pEffector;
    public float waitTime;

    void Start()
    {
        pEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {

                pEffector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                Debug.Log("entraDelta");
                waitTime -= Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            pEffector.rotationalOffset = 0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pEffector.rotationalOffset = 0f;
        }
    }
}
