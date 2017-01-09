using UnityEngine;
using System.Collections;
using System;

public class CoinsTree : TreeComposite
{

    public CoinsTree() : base(GameObjectType.ITEM)
    {

    }

    // Use this for initialization
    void Start()
    {
        //Create the Coin
        for (int i = 0; i < GameRules.GetMaxCoins(); i++)
        {
            GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Collectibles/Coin"), new Vector3(), new Quaternion());
            //Set parent
            tObj.transform.parent = this.transform;
            Coins tBlock = tObj.GetComponent<Coins>();
            //Move upwards
            //tBlock.transform.position = new Vector3(0.0f, tBlock.mySprite.transform.localScale.y * i, 0.0f);
            //name it
            tBlock.gameObject.name = "Coin " + i.ToString();
            //Switch off object
            tObj.SetActive(false);
            //Since it starts off as inactive, add as reserve
            AddReserveChild(tBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Activate()
    {

    }

    public override void Deactivate()
    {

    }

    public override void Row(Vector3 _target)
    {
       
    }
}
