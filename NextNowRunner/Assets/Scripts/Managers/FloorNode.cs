using UnityEngine;
using System.Collections;

public class FloorNode : GameObjectNode
{
    public FloorNode() : base(BaseType.FLOOR)
    {
       
    }

    void Start()
    {
        //New tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/FloorTree"), new Vector3(), new Quaternion());
        nuObj.transform.parent = this.transform;
        myTree = nuObj.GetComponent<FloorTree>();
    }
}
