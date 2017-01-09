using UnityEngine;
using System.Collections;

public class Kickstarter : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        //Game Object manager always goes first!!!
		GameObjectManager.Kickstart();

    }
	
	// Update is called once per frame
	void Update ()
    {
        GameStateMachine.Execute();
        //Update the EventManager
        EventManager.Tick(Time.deltaTime);
	}
}
