using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    //Observer
    private ControllObserver observer;
    private EndObserver endObs;
    //The player capsule
    public Player mPlayer;

	// Use this for initialization
	void Start ()
    {
        observer = new ControllObserver(this);
        endObs = new EndObserver(this);
        GSM.RegisterObserver(observer);
        GSM.RegisterEndObserver(endObs);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GSM.CanPlay())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mPlayer.Jump();
            }
        }
	}


}
