using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    private Camera mainCam;

	private float GlobalTime;
	// Use this for initialization
	void Start ()
    {
        mainCam = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GameStateMachine.CanPlay())
        {

// #if UNITY_ANDROID || UNITY_IOS
            //Touch controls
            if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Shout Row!!! o.o
                FloorManager.RowFloor();

                //Move the ropper in the desired direction
                if (Input.mousePosition.x > (Screen.width / 2.0f))
                {
                    PlayerFSM.MoveToRight();
                }
                else
                {
                    PlayerFSM.MoveToLeft();
                }

                ScoreManager.AddPoint();
            }
//#else
            //Debug controls
            //Mouse down
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Shout Row!!! o.o
                FloorManager.RowFloor();

                //Move the ropper in the desired direction
                if (Input.mousePosition.x > (Screen.width / 2.0f))
                {
                    PlayerFSM.MoveToRight();
                }
                else
                {
                    PlayerFSM.MoveToLeft();
                }

                ScoreManager.AddPoint();
            }

//#endif
            GlobalTime += Time.deltaTime;
            //Drain the player's energy
			PlayerFSM.DrainEnergy(Time.fixedDeltaTime+(float)(GlobalTime*0.000077));
        }
	}
}
