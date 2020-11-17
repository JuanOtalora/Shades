using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
  
    Rigidbody2D rgb;
    public float speed = 4.0f;
    public Vector2 movement;
    public Animator animatorC;
    Vector3 characterMovement;
    public float jumpForce = 400f;
    public CircleCollider2D groundFox;
    public bool grounded;
    public BoxCollider2D headFox;
    public bool isCrouched;
    public bool facingRight;
    public GameObject killzone;

    // Start is called before the first frame update
    void Start()
    {
        rgb = this.GetComponent<Rigidbody2D>();
        facingRight = true;
        groundFox = this.GetComponent<CircleCollider2D>();
        headFox = this.GetComponent<BoxCollider2D>();
        grounded = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Mathf.Abs(Mathf.Ceil(Input.GetAxis("Horizontal"))) > 0)
        {
            animatorC.SetFloat("Speed", 1);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            animatorC.SetFloat("Speed", 0);
        }
        DownWard();
        float HorizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.DownArrow) && !isCrouched)
        {
            Crouch();
        }
        else if (!Input.GetKey(KeyCode.DownArrow) && isCrouched)
        {
            headFox.enabled = true;
            isCrouched = false;
            animatorC.SetBool("Crouched", false);
            speed = 4.0f;
        }
        Flip(HorizontalMovement);
        CharacterMovement(Input.GetAxis("Horizontal"), 0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            //Do what you want when it collided with the ground
            animatorC.SetBool("Down", false);
            grounded = true;
        }
        else if(other.gameObject.transform.tag == "Obstacle")
        {
            animatorC.SetBool("Down", false);
            grounded = true;
        }else if (other.gameObject.transform.tag == "Spike") 
        {
            this.gameObject.SetActive(false);
        }
        else if (other.gameObject.transform.tag == "Platform")
        {
            animatorC.SetBool("Down", false);
            grounded = true;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            //Do what you want when it collided with the ground
            animatorC.SetBool("Down", false);
            grounded = true;
        }
        else if (other.gameObject.transform.tag == "Obstacle")
        {
            animatorC.SetBool("Down", false);
            grounded = true;
        }
        else if (other.gameObject.transform.tag == "Platform")
        {
            animatorC.SetBool("Down", false);
            grounded = true;
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
      
    }


    void Flip(float horizontal)
    {
        if (!facingRight && horizontal > 0)
        {
            Vector3 y = new Vector3(0, 180, 0);
            transform.Rotate(y);
            facingRight = true;
        }
        else if(facingRight && horizontal < 0)
        {
            Vector3 y = new Vector3(0, 180, 0);
            transform.Rotate(y);
            facingRight = false;
        }
       
    }

    public void ActivateShadow()
    {
        killzone.SetActive(false);
        this.gameObject.SetActive(true);
        this.transform.position = new Vector3(64.6f, -16.84f);

    }


    void CharacterMovement(float h, float v)
    {
        characterMovement = new Vector3(h, v, 0f);
        transform.position += characterMovement * Time.deltaTime * speed;
    }


    void DownWard()
    {
        if (rgb.velocity.y < 0)
        {
            animatorC.SetBool("Down", true);
            animatorC.SetBool("Jump", false);
        }
    }


    void Crouch()
    {
        speed = 2.0f;
        headFox.enabled = false;
        isCrouched = true;
        animatorC.SetBool("Crouched", true);
    }
}
