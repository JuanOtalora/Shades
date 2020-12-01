using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadow : MonoBehaviour
{

    public GameObject player;
    public GameObject shadowPlayer;
    public GameObject otherLamp;
    public Animator animatorL;
    public Animator animatorLS;
    float distance;
    float maxDistance = 1.0f;
    private AudioSource ignite;

    // Start is called before the first frame update
    void Start()
    {
        ignite = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+0.1f);
                shadowPlayer.transform.position = new Vector3(otherLamp.transform.position.x, otherLamp.transform.position.y + 0.1f);
                animatorL.SetBool("TurnedOn", true);
                animatorLS.SetBool("TurnedOn", true);
                ignite.Play();

            }
        }

    }
}
