using UnityEngine;
using System.Collections;

public class BlockNode : ManagerNode
{

    public BlockNode() : base(GameObjectType.BLOCK)
    {

    }
    public static BlockNode i;

    void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start ()
    {
        //Create my Tree
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/BuildingBlock/BlockTree"), new Vector3(), new Quaternion());
        tObj.transform.parent = this.transform;
        myTree = tObj.GetComponent<BlockTree>();

        if(myTree == null)
        {
            Debug.Log("dafuq??");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
