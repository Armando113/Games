using UnityEngine;
using System.Collections;

public class Player : SceneObject
{
    //The rigidbody
    private Rigidbody myRigidbody;
    //The Vector we will move 
    private Vector3 moveDir;
    //The speed of the player
    private float fSpeed;
    //The jump force
    private float fJumpForce;
    //The health
    private int health;
    //Are we touching the ground?
    private bool bIsGrounded;


    public Player() : base(BaseType.PLAYER)
    {
        fSpeed = 15.0f;
        fJumpForce = 0.0f;
        health = 3;
    }

    // Use this for initialization
    void Start ()
    {
        myRigidbody = this.GetComponent<Rigidbody>();

        if(myRigidbody == null)
        {
            Debug.Log("No rigidbody O.O");
        }
        //Set forward
        this.transform.forward = new Vector3(1.0f, 0.0f, 0.0f);
        //The direction we move
        moveDir = transform.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    //Update for the rigidbody
    void FixedUpdate()
    {
        //Set move vector
        moveDir.x = fSpeed * Time.deltaTime;
        moveDir.y = fJumpForce * Time.deltaTime;

        //Move
        this.transform.position += moveDir;

        //reduce jump force if available
        if(!bIsGrounded)
        {
            fJumpForce -= 9.81f * 0.5f;
        }

    }

    //Function for jump!
    public void Jump()
    {
        if(bIsGrounded)
        {
            fJumpForce = 45.0f;
        }
    }

    /*-----Collision Functions-----*/
    void OnCollisionEnter(Collision _collision)
    {
        SceneObject obj = _collision.transform.GetComponent<SceneObject>();

        switch(obj.GetBaseType())
        {
            case BaseType.FLOOR:
                //for now, just get the bool updated
                bIsGrounded = true;
                //reset the jump force
                fJumpForce = 0.0f;
                break;
            case BaseType.OBSTACLE:
                if(health > 0)
                {
                    health--;
                }
                else
                {
                    GSM.EnterGameOver();
                }

                Debug.Log("Bump");
                break;
        }

    }
    void OnCollisionStay(Collision _collision)
    {
        SceneObject obj = _collision.transform.GetComponent<SceneObject>();

        switch (obj.GetBaseType())
        {
            case BaseType.FLOOR:
                //for now, just get the bool updated
                bIsGrounded = true;
                //reset the jump force
                fJumpForce = 0.0f;
                break;
        }
    }
    void OnCollisionExit(Collision _collision)
    {
        //shoot a ray and detect the floor
        if (Physics.Raycast(this.transform.position, -this.transform.up, 1))
        {

        }
        else
        {
            bIsGrounded = false;
        }
        
    }

    /*-----Trigger Functions-----*/
    void OnTriggerEnter(Collider _collider)
    {
        //Check for coins
        Coin tCoin = _collider.transform.GetComponent<Coin>();

        if(tCoin != null)
        {
            tCoin.gameObject.SetActive(false);
            //Collect points here
        }
    }

    void OnTriggerExit(Collider _collider)
    {

    }

    public override void ActivateObject()
    {
        health = 3;
        this.transform.position = new Vector3(0.0f, 2.5f, 0.0f);
    }

}
