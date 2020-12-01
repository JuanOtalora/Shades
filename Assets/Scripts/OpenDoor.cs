using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject realDoor;
    public GameObject shadowDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.L))
            {

                realDoor.SetActive(false);
                shadowDoor.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.L))
            {

                realDoor.SetActive(false);
                shadowDoor.SetActive(false);
            }
        }
    }
}
