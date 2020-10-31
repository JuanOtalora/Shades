using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainPlayer;
    float distance;
    float maxDistance = 1.0f;

    public GameObject myPrefab;
    public GameObject shadow;
    private ShadowController script;

    void Start()
    {
        script = shadow.GetComponent<ShadowController>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(mainPlayer.transform.position, this.transform.position);
        if (distance <= maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Instantiate(myPrefab, new Vector3(56.65f, 1.48f, 0), Quaternion.identity);
                Instantiate(myPrefab, new Vector3(62.39f, 1.48f, 0), Quaternion.identity);
                Instantiate(myPrefab, new Vector3(67.53f, 1.48f, 0), Quaternion.identity);
                Instantiate(myPrefab, new Vector3(56.65f, -16.925f, 0), Quaternion.identity);
                Instantiate(myPrefab, new Vector3(62.39f, -16.925f, 0), Quaternion.identity);
                Instantiate(myPrefab, new Vector3(67.53f, -16.925f, 0), Quaternion.identity);
                script.ActivateShadow();
               
            }
        }
    }
}
