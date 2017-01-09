using UnityEngine;
using System.Collections;
using System;

public class RopperTree : TreeComposite
{

	string[] Characters = new string[]{"RopperGuy", "SimioGuy", "TarzanGuy", "PenaGuy", "TrumpGuy"};
    private int currChar;
    RopperGuy guy;
    public RopperTree() : base(GameObjectType.PLAYER)
    {

    }
    

    // Use this for initialization
    void Start ()
    {
        currChar = PlayerPrefs.GetInt("Character");
       guy = createRopper();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currChar != PlayerPrefs.GetInt("Character"))
        {
            Destroy(guy);
            guy = createRopper();
            currChar = PlayerPrefs.GetInt("Character");
        }
	}

    RopperGuy createRopper()
    {
        //Create the Ropper guy
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Ropper/" + Characters[PlayerPrefs.GetInt("Character")]), new Vector3(), new Quaternion());
        //Make it our transform's child
        tObj.transform.parent = this.transform;
        //Get the Ropper Script
        RopperGuy tGuy = tObj.GetComponent<RopperGuy>();

        tObj.SetActive(false);
        //Add it to our active list
        AddReserveChild(tGuy);
        return tGuy;
    }

    void ReturnRopper(RopperGuy _guy)
    {
        //Get the Block tree!
        RopperTree tTree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);
        //Check if the tree isn't null
        if (tTree != null)
        {
            //Return the object
            Destroy(_guy);
        }
    }
    public RopperGuy GetRopperGuy()
    {
        return (RopperGuy)pActiveChildHead;
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
