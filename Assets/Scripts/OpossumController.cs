using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumController : MonoBehaviour
{

    public float speed = 4.0f;
    private bool facingLeft = true;
    public Vector2 movement;
    Vector3 characterMovement;
    public int x = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CharacterMovement(x);
    }

    void CharacterMovement(float h)
    {
        characterMovement = new Vector3(h, 0f, 0f);
        this.transform.position += characterMovement * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("EntraRRRR");
        if (other.gameObject.transform.tag == "Obstacle")
        {
            //Do what you want when it collided with the ground
            Debug.Log("Entra");
            Flip();
        }
        else
        {

        }
    }

   


    void Flip()
    {
        if (facingLeft && x == -1)
        {
            Vector3 y = new Vector3(0, 180, 0);
            transform.Rotate(y);
            facingLeft = false;
            x = 1;
        }else if (!facingLeft && x == 1)
        {
            Vector3 y = new Vector3(0, 180, 0);
            transform.Rotate(y);
            facingLeft = true;
            x = -1;
        }
    }
}
