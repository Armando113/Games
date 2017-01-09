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
                //Call the PlayerFSM OnTap
                PlayerFSM.OnTap(Input.GetTouch(0));
            }

            
//#else
            //Debug controls
            //Mouse down
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Call PlayerFSM Ontap
                PlayerFSM.OnTap(KeyCode.Mouse0);
            }

//#endif
            GlobalTime += Time.deltaTime;
            //Drain the player's energy
            if(PlayerFSM.GetCurrentCtrlMode().GetCtrlType() == CtrlType.GAME)
            {
                GameCtrl tCtrl = (GameCtrl)PlayerFSM.GetCurrentCtrlMode();
                tCtrl.GetRopperGuy().DrainEnergy(Time.fixedDeltaTime + (float)(GlobalTime * 0.00077f));
            }
			//PlayerFSM.DrainEnergy(Time.fixedDeltaTime+(float)(GlobalTime*0.000077));
        }
        if (!GameStateMachine.CanPlay())
        {
            GlobalTime = 0.0f;
        }

    }
}
