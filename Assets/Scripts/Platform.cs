using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D pEffector;
    public float waitTime;
    private bool bajando;

    void Start()
    {
        pEffector = GetComponent<PlatformEffector2D>();
        bajando = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!bajando)
            {

                pEffector.rotationalOffset = 180f;
                bajando = true;
            }
            else
            {
                bajando = false;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {

            pEffector.rotationalOffset = 0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("ENTRA");
            pEffector.rotationalOffset = 0f;
        }
    }

}
