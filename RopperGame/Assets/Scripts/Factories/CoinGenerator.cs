using UnityEngine;
using System.Collections;

public class CoinGenerator
{

    private static CoinGenerator pInstance;
    private int rndLimit;
    private CoinGenerator()
    {

        rndLimit = 40;
        
    }

    private static CoinGenerator GetInstance()
    {
        if (pInstance == null)
        {
            pInstance = new CoinGenerator();
        }
        return pInstance;
    }

    
    public static bool SetCoins(RopeEnum _leftRope, RopeEnum _rightRope, out Coins _left, out Coins _right)
    {
        //Random Obstacles
        int rndNum = Random.Range(0, GetInstance().rndLimit);
       
          
                //Left rope goes first
                if (rndNum == 1)
                {
                    _left = null;
                    _right = null;
                    if (_leftRope == RopeEnum.STRONG)
                    {
                        _left = CoinFactory.GetCoin();
                    }
                    else if (_rightRope == RopeEnum.STRONG)
                    {
                        _right = CoinFactory.GetCoin();
                    }
                    return true;
                }


        //In case everything goes to hell
        _left = null;
        _right = null;
        return false;
        }
}


