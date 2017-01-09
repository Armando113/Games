using UnityEngine;
using System.Collections;

public class UIManager
{

    private static UIManager pInstance;

    //Our UI panels
    private static GameObject menu;
	private static GameObject introlevel;
    private static GameObject game;
    private static GameObject gameOver;


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
        menu = PanelContainer.GetMenuPanel();
		introlevel = PanelContainer.GetIntroPanel ();
        game = PanelContainer.GetGamePanel();
        gameOver = PanelContainer.GetGameOverPanel();


        SwitchToIntro();
    }

    private static void SwitchUIOff()
    {
        menu.gameObject.SetActive(false);
		introlevel.gameObject.SetActive (false);
        game.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
      
    }

    public static void SwitchToMenu()
    {
        SwitchUIOff();
      
        menu.gameObject.SetActive(true);
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

    public static void SwitchToGameOver()
    {
        SwitchUIOff();

        gameOver.gameObject.SetActive(true);
       
    }
    
}
