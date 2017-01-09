using UnityEngine;
using System.Collections;

public class PlayerTree : TreeComposite
{
    public PlayerTree() : base(BaseType.PLAYER)
    {
    }

    // Use this for initialization
    void Start ()
    {
	
	}

    public Player GetPlayer()
    {
        return (Player)pActiveHead;
    }

    public override void ActivateObject()
    {
        Player tPlayer = (Player)PopReserveChild();
        //Create player here
        if(tPlayer == null)
        {
            GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0.0f, 2.5f, 0.0f), new Quaternion());
            nuObj.transform.parent = this.transform;
            tPlayer = nuObj.GetComponent<Player>();
        }
        //activate 
        tPlayer.gameObject.SetActive(true);
        tPlayer.ActivateObject();
        //Add to active
        AddActiveChild(tPlayer);
    }

    public override void DeactivateObject()
    {
        Player tPlayer = (Player)pActiveHead;

        if(tPlayer == null)
        {
            return;
        }
        //Deactivate
        tPlayer.gameObject.SetActive(false);
        //Add to reserve
        RemoveActiveChild(tPlayer);
        AddReserveChild(tPlayer);

    }
}
