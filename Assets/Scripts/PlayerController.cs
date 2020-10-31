using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  
    Rigidbody2D rgb;
    public float speed = 4.0f;
    public Vector2 movement;
    public Animator animatorC;
    Vector3 characterMovement;
    public float jumpForce = -400f;
    public CircleCollider2D groundFox;
    public bool grounded;
    public BoxCollider2D headFox;
    public bool isCrouched;
    public bool facingRight;
    public bool shadowMode = false;
    public bool onLadder = false;

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
        Jump();
        //if (Input.GetKey(KeyCode.DownArrow) && !isCrouched)
        //{
        //    Crouch();
        //}
        //else if (!Input.GetKey(KeyCode.DownArrow) && isCrouched)
        //{
        //    headFox.enabled = true;
        //    isCrouched = false;
        //    animatorC.SetBool("Crouched", false);
        //    speed = 4.0f;
        //}
        Flip(HorizontalMovement);
        CharacterMovement(Input.GetAxis("Horizontal"), Jump());
        if (onLadder)
        {
            CharacterMovement(0, Input.GetAxis("Vertical") * 2);
            Debug.Log("entra a ladder");
           rgb.gravityScale = 0;
        }
        else
        {
            Debug.Log("entra a cambio");
            rgb.gravityScale = 2;
        }
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
        }else if (other.gameObject.transform.tag == "Enemy")
        {

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
            onLadder = false;
        }
        else if (other.gameObject.transform.tag == "Spike") 
        {
            SceneManager.LoadScene("FirstLevel");

        }
        else if (other.gameObject.transform.tag == "Ladder") 
        {
            animatorC.SetBool("OnLadder", true);
            onLadder = true;
        }
        else
        {

            onLadder = false;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Ladder")
        {
            //Do what you want when it collided with the ground
            onLadder = false;
            animatorC.SetBool("OnLadder", false);

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

    void CharacterMovement(float h, float v)
    {
        characterMovement = new Vector3(h, v, 0f);
        transform.position += characterMovement * Time.deltaTime * speed;
    }

    float Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded) {
            animatorC.SetBool("Jump", true);
            rgb.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }
        return 0;
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
