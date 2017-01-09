using UnityEngine;
using System.Collections;

public class BirdNode : ManagerNode
{

    public BirdNode() : base(GameObjectType.OBSTACLE)
    {

    }
    public static BirdNode i;

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
    void Start()
    {
        //Create my Tree
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Obstacle/BirdTree"), new Vector3(), new Quaternion());
        tObj.transform.parent = this.transform;
        myTree = tObj.GetComponent<BirdTree>();

        if (myTree == null)
        {
            Debug.Log("dafuq??");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
