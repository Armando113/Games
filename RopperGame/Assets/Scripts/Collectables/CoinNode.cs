using UnityEngine;
using System.Collections;

public class CoinNode : ManagerNode
{

    public CoinNode() : base(GameObjectType.ITEM)
    {

    }
    public static CoinNode i;

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
    void Start () {
        //Create my Tree
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Collectibles/CoinTree"), new Vector3(), new Quaternion());
        tObj.transform.parent = this.transform;
        myTree = tObj.GetComponent<CoinsTree>();

        if (myTree == null)
        {
            Debug.Log("dafuq??");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
