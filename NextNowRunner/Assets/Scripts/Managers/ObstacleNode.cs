using UnityEngine;
using System.Collections;

public class ObstacleNode : GameObjectNode
{
    public ObstacleNode() : base(BaseType.OBSTACLE)
    {
    }

    // Use this for initialization
    void Start ()
    {
        //New tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/ObstacleTree"), new Vector3(), new Quaternion());
        nuObj.transform.parent = this.transform;
        myTree = nuObj.GetComponent<ObstacleTree>();
    }
	
}
