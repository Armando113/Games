using UnityEngine;
using System.Collections;

public class GameRules
{
    //Instance of the class
    private static GameRules pInstance;
	private int maxBlocks;
	private int maxRopes;
    private int maxCoins;
    //"Global Brick" Rules
    private Vector3 deathPos;
    private Vector3 B_resetPos;
	//"Left Ropes" Rules
	private Vector3 Ropel_resetPos;
	private Vector3 Ropel_deathPos;
	//"Right Ropes" Rules
	private Vector3 Roper_resetPos;
	private Vector3 Roper_deathPos;

	private float globalSpeed;

    private float lowEnergy;
    private float highEnergy;

    private GameRules()
    {
		//The position for when to reposition blocks.
		deathPos = new Vector3(0.0f, -2.05f, 0.0f);

		//The position for when to reposition right ropes.
		Roper_deathPos = new Vector3(0.8f, -2.05f, 0.0f);

		//The position for when to reposition left ropes.
		Ropel_deathPos = new Vector3(-0.8f, -2.05f, 0.0f);

        //The position to place the block
		B_resetPos = new Vector3(0.0f, 12.1f, -0.41f);

		//The position to place Left Ropes
		Ropel_resetPos = new Vector3(-0.8f, 12.1f, -0.41f);

		//The position to place Right  Ropes
		Roper_resetPos = new Vector3(0.8f, 12.1f, -0.41f);

        //Maximum number of blocks in scene
        maxBlocks = 7;
		//Maximum number of ropes in each line.
		maxRopes = maxBlocks * 2;
        //Maximum number of Coins in each line
        maxCoins = 1;
        //The speed for all objects in scene
        globalSpeed = 0.5f;

        lowEnergy = 0.4f;


    }

    private static GameRules GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new GameRules();
        }
        return pInstance;
    }
	//Obtain the death position.
    public static Vector3 GetBDeathPosition()
    {
		return GetInstance().deathPos;
    }
	//Reset the position for the blocks.
    public static Vector3 GetBResetPosition()
    {
		return GetInstance().B_resetPos;
    }

	//Obtain the death position.
	public static Vector3 GetRope_rDeathPosition()
	{
		return GetInstance().Roper_deathPos;
	}

	//Reset the position for the right Ropes.
	public static Vector3 GetRope_rResetPosition()
	{
		return GetInstance().Roper_resetPos;
	}

	//Obtain the death position.
	public static Vector3 GetRope_lDeathPosition()
	{
		return GetInstance().Ropel_deathPos;
	}

	//Reset the position for the left Ropes.
	public static Vector3 GetRope_lResetPosition()
	{
		return GetInstance().Ropel_resetPos;
	}

	public static int GetMaxBlocks()
	{
		return GetInstance ().maxBlocks;
	}
	public static int GetMaxRopes()
	{
		return GetInstance ().maxRopes;
	}
    public static int GetMaxCoins()
    {
        return GetInstance().maxCoins;
    }

    public static float GetGlobalSpeed()
	{
		return GetInstance ().globalSpeed;
	}

    public static float GetLowEnergy()
    {
        return GetInstance().lowEnergy;
    }


}
