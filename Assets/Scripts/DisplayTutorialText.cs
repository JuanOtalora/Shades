using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTutorialText : MonoBehaviour
{
    public GameObject text;
    public GameObject image;
    public GameObject playerNear;
    float maxDistance = 1.0f;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerNear.transform.position, this.transform.position); 
        if (distance <= maxDistance)
        {
            text.SetActive(true);
            image.SetActive(true);
        }
        else
        {
            text.SetActive(false);
            image.SetActive(false);
        }
    }
}
