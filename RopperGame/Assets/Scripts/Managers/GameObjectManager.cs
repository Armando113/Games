using UnityEngine;
using System.Collections;


public class GameObjectManager : Manager
{
	//Static Instance.
	private static GameObjectManager pInstance;

	//Default constructor 
	private GameObjectManager ():base()
	{
		//Create the nodes here

		//We start off with the block

		GameObject tObj = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/BuildingBlock/BlockNode"), new Vector3 (), new Quaternion ());
		ManagerNode tNode = tObj.GetComponent<ManagerNode>();
		AddActive (tNode);

		//The ropper node
		tObj = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/Ropper/RopperNode"), new Vector3 (), new Quaternion ());
		tNode = tObj.GetComponent<ManagerNode> ();
		AddActive (tNode);
       

		//The ropes node
		tObj = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/RopeBuilder/RopeNode"), new Vector3 (), new Quaternion ());
		tNode = tObj.GetComponent<ManagerNode> ();
		AddActive (tNode);

        //The coins node
        tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Collectibles/CoinNode"), new Vector3(), new Quaternion());
        tNode = tObj.GetComponent<ManagerNode>();
        AddActive(tNode);

        //The Bird node
        tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Obstacle/BirdNode"), new Vector3(), new Quaternion());
        tNode = tObj.GetComponent<ManagerNode>();
        AddActive(tNode);
    }

	private static GameObjectManager GetInstance()
	{
		if(pInstance == null)
		{
			pInstance = new GameObjectManager();
		}
		return pInstance;
	}

	public static void Kickstart()
	{
		GetInstance ();
	}

	public static TreeComponent GetTree(GameObjectType _type)
	{
		GetInstance ().pIterator.SetStartNode (GetInstance ().pActiveHead);

		//walk the list and return the desired tree
		while (GetInstance().pIterator.GetNode() != null) 
		{
            ManagerNode tnode = (ManagerNode)GetInstance().pIterator.GetNode();
            //Did we find the tree?
            if (tnode.GetObjectType() == _type)
			{
                //found it!!
				return tnode.GetMyTree();
			}
			//keep walking
			GetInstance().pIterator.GoNext();
		}

		//this is in case everything goes to hell
		return null;
	}

	//Action Methods

	//Row!!
	public static void Row(Vector3 _target)
	{
		//Walk our list and row
		GetInstance ().pIterator.SetStartNode (GetInstance ().pActiveHead);

		while (GetInstance().pIterator.GetNode()!=null) 
		{
			ManagerNode tNode = (ManagerNode)GetInstance().pIterator.GetNode();

			//Call the function
			tNode.Row(_target);

			//keep walking johny
			GetInstance().pIterator.GoNext();
		}
	}
    void Update()
    {
        //Update the EventManager
        EventManager.Tick(Time.deltaTime);
    }

}
