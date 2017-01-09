using UnityEngine;
using System.Collections;

public class CoinGenerator : SceneObject
{

    private Player mPlayer;
    private BDQueue<Coin> coinQueue;
    private float fMaxResetDist;

    public CoinGenerator() : base(BaseType.ITEM)
    {
        coinQueue = new BDQueue<Coin>();
        fMaxResetDist = 40.0f;
    }

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(GSM.CanPlay())
        {
            MoveCoins();
        }
	}

    private void MoveCoins()
    {
        if (mPlayer == null)
        {
            mPlayer = PlayerFactory.GetPlayerReference();
        }

        if (mPlayer == null)
        {
            return;
        }

        if (Vector3.Distance(coinQueue.PeekFront().GetPosition(), mPlayer.GetPosition()) > fMaxResetDist)
        {
            //Move floor 
            Coin coin = coinQueue.PopFront();
            //Move it to the further back
            coin.transform.position = new Vector3(coinQueue.PeekBack().transform.position.x + 15.0f, mPlayer.transform.position.y, 0.0f);
            //add to the back
            coinQueue.EnqueueBack(coin);
            //Reactivate
            coinQueue.PeekBack().gameObject.SetActive(true);
        }
    }

    public override void ActivateObject()
    {
        //Get 5 floors
        for (int i = 0; i < 10; i++)
        {
            //Create a block
            coinQueue.EnqueueFront(CoinFactory.CreateCoin());
            //Move the block
            coinQueue.PeekFront().transform.position = new Vector3((i * 15.0f), 2.5f, 0.0f);
        }
    }

    public override void DeactivateObject()
    {
        while (coinQueue.PeekFront() != null)
        {
            CoinFactory.ReturnCoin(coinQueue.PopFront());
        }
    }
}
