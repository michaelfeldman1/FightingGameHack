using System.Collections;
using UnityEngine;

public class BodyScript : MonoBehaviour
{

    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    public void setMovement(bool enable)
    {
        if (enable == true)
        {

        }

        else
        {
            movement = 0.0f;
        }


    }


    // Update is called once per frame
    void Update()
    {

        // Will make a true of false based off of the parameters we have set
        // over in Unity 
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);


        // These 2 puppies right here let us do flips
        // By using the input from game's set Horizontal 
        // keys of (A and D)
        movement = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, movement * 2 * (-1));

        // Could maybe create a variable somewhere in here to track how much
        // rotation has been done to be able to count flip score



        // This puppy is for jumping.
        // We are using the "Jump" part of the Input Manager.
        // Still need to make sure we make contact with the
        // mountain or ramp before we execute the jump
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }







    }




    // When the player comes in contact with certain points
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bronze"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("silver"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("gold"))
        {
            Destroy(other.gameObject);
        }


    }

    */

}
