using UnityEngine;
using System.Collections;

public class ItemNode : GameObjectNode
{
    public ItemNode() : base(BaseType.ITEM)
    {
    }

    // Use this for initialization
    void Start ()
    {
        //New tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/ItemTree"), new Vector3(), new Quaternion());
        nuObj.transform.parent = this.transform;
        myTree = nuObj.GetComponent<ItemTree>();
    }
}
