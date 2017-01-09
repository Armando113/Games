using UnityEngine;
using System.Collections;

public class RopeNode : ManagerNode {

	public RopeNode() : base(GameObjectType.ROPE)
	{
		
	}
    public static RopeNode i;

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
		GameObject tObj = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/RopeBuilder/RopeTree"), new Vector3 (), new Quaternion ());
		tObj.transform.parent = this.transform;
		myTree = tObj.GetComponent<TreeComponent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
