using UnityEngine;
using System.Collections;

public class Levers : MonoBehaviour
{
    public GameObject shadowPlayer;
    float distance;
    float maxDistance = 2.0f;
    public GameObject spikes1;
    public GameObject spikes2;
    public GameObject spikes3;
    public GameObject spikes4;
    public Animator animatorL;
    public Animator animatorLS;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(shadowPlayer.transform.position, this.transform.position);
        if (distance <= maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                animatorL.SetBool("Active", true);
                animatorLS.SetBool("Active", true);
                Destroy(spikes1);
                Destroy(spikes2);
                Destroy(spikes3);
                Destroy(spikes4);
            }
        }
    }
}
