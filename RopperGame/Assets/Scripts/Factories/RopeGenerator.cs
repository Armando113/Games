using UnityEngine;
using System.Collections;

public class RopeGenerator
{

    private static RopeGenerator pInstance;
    private int rndLimit;


    private RopeGenerator()
    {
        rndLimit = 2;

    }

    private static RopeGenerator GetInstance()
    {
        if (pInstance == null)
        {
            pInstance = new RopeGenerator();
        }
        return pInstance;
    }

    public static bool SetFloorRopes(out Rope _left, out Rope _right)
    {

        //Starting

        //Random Obstacles
        int rndNum = Random.Range(-(GetInstance().rndLimit - 1), GetInstance().rndLimit);

        if (rndNum > 0)
        {
            //The Right rope is weak
            _left = RopeFactory.GetStrongRope();
            _right = RopeFactory.GetWeakRope();
            return true;
        } else if (rndNum < 0)
        {
            //TheLeft rope is weak
            _left = RopeFactory.GetWeakRope();
            _right = RopeFactory.GetStrongRope();
            return true;
        }
   
        //In case everything goes to hell
        _left = RopeFactory.GetStrongRope();
        _right = RopeFactory.GetStrongRope();
        return false;
     }
  }


