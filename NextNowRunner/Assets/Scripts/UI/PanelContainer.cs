using UnityEngine;
using System.Collections;

public class PanelContainer : MonoBehaviour
{

	public GameObject introPanel;
    public GameObject gamePanel;

	private static GameObject staticIntro;
    private static GameObject staticGame;

    private PanelContainer()
    {

    }

	// Use this for initialization
	void Start ()
    {
		staticIntro = introPanel;
        staticGame = gamePanel;

        UIManager.Kickstart();
	}
	
	public static GameObject GetIntroPanel()
	{
		return staticIntro;
	}

    public static GameObject GetGamePanel()
    {
        return staticGame;
    }



}
