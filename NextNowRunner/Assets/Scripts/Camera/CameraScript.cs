using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public Player mPlayer;

    //The camera
    private Camera myCam;

	// Use this for initialization
	void Start ()
    {
        myCam = this.GetComponent<Camera>();

        if(myCam == null)
        {
            Debug.Log("Camera not found, WTF??");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FixedUpdate()
    {
        if(GSM.CanPlay())
        {
            if (mPlayer == null)
            {
                mPlayer = PlayerFactory.GetPlayerReference();
            }
            this.transform.position = new Vector3(mPlayer.GetPosition().x, this.transform.position.y, this.transform.position.z);
        }
        
    }
}
