using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplePlatformController : MonoBehaviour {

    // Use this for initialization
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000;
    public Transform groundCheck;



    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //disables being able to double jump. change if we want to double jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //stopped video at 13 minutes@$&$*(#@&$*(&#@(*$&(*$@
        anim.SetFloat("Speed", Mathf.Abs(h));
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
