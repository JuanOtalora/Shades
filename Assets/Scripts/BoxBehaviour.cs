using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxBehaviour : MonoBehaviour
{
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            body.AddForce(Vector2.right * 1);
        }
    }

}
