using UnityEngine;
using System.Collections;

public class Floor
{
    //This class will hold a reference to all objects in one floor
    //Such as a Building Block, coins, Ropes, ETC.

    protected BuildingBlock myBlock;

    protected Rope leftRope;

    protected Rope rightRope;

    protected Coins rightCoin;

    protected Coins leftCoin;


    //When the time comes, items will be here too
    public Floor()
    {

    }

    public BuildingBlock GetBlock()
    {
        return myBlock;
    }

    public Rope GetLeftRope()
    {
        return leftRope;
    }

    public Rope GetRightRope()
    {
        return rightRope;
    }

    public bool CollectRightCoin()
    {
        if (rightCoin != null)
        {
            //Return the coin
            CoinFactory.ReturnCoin(rightCoin);
            //Make it null
            rightCoin = null;
            //Return success
            return true;
        }
        //No coin :'(
        return false;
    }

    public bool CollectLeftCoin()
    {
        if(leftCoin != null)
        {
            //Return the coin
            CoinFactory.ReturnCoin(leftCoin);
            //Make it null
            leftCoin = null;
            //Return success
            return true;
        }
        //No coin :'(
        return false;
    }

    public void GetNewAssets(int _index)
    {
        //Here is where we will set our assets

        //Set the BuildingBlock
        //Get and Set a building block
        SetBlock(_index);

        //Left Rope
        SetLeftRope();

        //Right Rope
        SetRightRope();
    }

    public void DeleteAssets()
    {
        //Return assets to respective factories
        //Delete the block
        BlockFactory.ReturnBlock(this.myBlock);
        this.myBlock = null;

        //Delete the left rope
        RopeFactory.ReturnRope(this.leftRope);
        this.leftRope = null;

        //Delete the Right rope
        RopeFactory.ReturnRope(this.rightRope);
        this.rightRope = null;

        //Delete the left coin
        CoinFactory.ReturnCoin(this.leftCoin);
        this.leftCoin = null;

        //Delete the Right coin
        CoinFactory.ReturnCoin(this.rightCoin);
        this.rightCoin = null;


    }

    public void SetPosition(Vector3 _position)
    {
        //Set the position for all assets
        //Block
        myBlock.transform.position = _position;

        //Left Rope
        leftRope.ForceNewPosition(new Vector3(-0.55f, _position.y, _position.z));

        //Right Rope
        rightRope.ForceNewPosition(new Vector3(0.55f, _position.y, _position.z));

        if(leftCoin != null)
        {
            //Left Coin
            leftCoin.transform.position = (new Vector3(-0.55f, _position.y, _position.z));
        }

        if(rightCoin != null)
        {
            //Right Coin
            rightCoin.transform.position = (new Vector3(0.55f, _position.y, _position.z));
        }
    }

    public void Row(Vector3 _target)
    {
        //Row Block
        myBlock.Row(_target);

        //Left Rope
        leftRope.Row(new Vector3(-0.55f, _target.y, _target.z));

        //Right Rope
        rightRope.Row(new Vector3(0.55f, _target.y, _target.z));

        if(leftCoin != null)
        {
            //Left Coin
            leftCoin.Row(new Vector3(-0.55f, _target.y, _target.z));
        }

        if(rightCoin != null)
        {
            //Right Coin
            rightCoin.Row(new Vector3(0.55f, _target.y, _target.z));
        }
    }
	
    public bool IsRowing()
    {
        //Check that all of your items aren't rowing, otherwise return true
        if(!myBlock.IsRowing())
        {
            return false;
        }

        return true;
    }

    private void SetBlock(int _index)
    {
        this.myBlock = BlockFactory.CreateBlock();

        this.myBlock.GetSpriteRenderer().sprite = BlockSpriteFactory.GetSprite(_index);
    }

    private void SetLeftRope()
    {
        this.leftRope = RopeFactory.GetStrongRope();
    }

    private void SetRightRope()
    {
        this.rightRope = RopeFactory.GetStrongRope();
    }
    private void SetRightCoin()
    {
        this.rightCoin = CoinFactory.GetCoin();
    }
    private void SetLeftCoin()
    {
        this.leftCoin = CoinFactory.GetCoin();
    }

    public void ResetContent()
    {
        //Here is where you will reset the content of the floor
        myBlock.GetSpriteRenderer().sprite = BlockSpriteFactory.GetRandomSprite();

        //Return our current left rope
        RopeFactory.ReturnRope(this.leftRope);
        //Return our current right rope
        RopeFactory.ReturnRope(this.rightRope);

        //Return our current left coin
        CoinFactory.ReturnCoin(this.leftCoin);
        //Return our current right coin
        CoinFactory.ReturnCoin(this.rightCoin);

        //Set our ropes
        RopeGenerator.SetFloorRopes(out this.leftRope, out this.rightRope);
        //this guy is the one with troubles...
        CoinGenerator.SetCoins(this.leftRope.GetRopeType(), this.rightRope.GetRopeType(), out this.leftCoin, out this.rightCoin);

        //Set the position
        this.leftRope.ForceNewPosition(new Vector3(-0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - (BuildingBlock.BlockHeight * 2), 0.0f));
        //Set the position
        this.rightRope.ForceNewPosition(new Vector3(0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - (BuildingBlock.BlockHeight * 2), 0.0f));

        if(leftCoin != null)
        {
            //Set the position
            this.leftCoin.ForceNewPosition(new Vector3(-0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - (BuildingBlock.BlockHeight * 2), 0.0f));
        }

        if(rightCoin != null)
        {
            //Set the position
            this.rightCoin.ForceNewPosition(new Vector3(0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - (BuildingBlock.BlockHeight * 2), 0.0f));
        }
    }

}
