using UnityEngine;
using System.Collections;

public class UIManager
{
    private static UIManager pInstance;
    //Our UI panels
	private static GameObject introlevel;
    private static GameObject game;


    private UIManager()
    {
        
    }

    private static UIManager GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new UIManager();
        }
        return pInstance;
    }

    public static void Kickstart()
    {
		introlevel = PanelContainer.GetIntroPanel ();
        game = PanelContainer.GetGamePanel();

        SwitchToIntro();
    }

    private static void SwitchUIOff()
    {
		introlevel.gameObject.SetActive (false);
        game.gameObject.SetActive(false);
    }

	public static void SwitchToIntro()
	{
		SwitchUIOff();

		introlevel.gameObject.SetActive(true);
	}
    public static void SwitchToGame()
    {
        SwitchUIOff();

        game.gameObject.SetActive(true);
    }
    
}
