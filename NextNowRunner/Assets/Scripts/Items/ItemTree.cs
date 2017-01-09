using UnityEngine;
using System.Collections;

public class ItemTree : TreeComposite
{
    public ItemTree() : base(BaseType.ITEM)
    {

    }

    // Use this for initialization
    void Start ()
    {
	
	}

    public Coin GetCoin()
    {
        Coin coin = (Coin)PopReserveChild();

        if(coin == null)
        {
            GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Coin"), new Vector3(), new Quaternion());
            coin = nuObj.GetComponent<Coin>();
            nuObj.transform.parent = this.transform;
        }
        //Set active
        coin.gameObject.SetActive(true);
        //Add Active
        AddActiveChild(coin);

        return coin;
    }

    public void ReturnCoin(Coin _coin)
    {
        if(FindActive(_coin) == null)
        {
            return;
        }

        //Remove from active
        RemoveActiveChild(_coin);
        //Deactivate
        _coin.gameObject.SetActive(false);
        //add to active
        AddReserveChild(_coin);
    }


}
