using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 10;

    public Vector2 movement;

    private Rigidbody2D rb;

    // float verticalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if(!Mathf.Approximately(0, movement.x)){
            transform.rotation = movement.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }

    void FixedUpdate(){
        // Move our character
        transform.position += new Vector3(movement.x, 0,0)  * moveSpeed * Time.deltaTime;
    }
}
