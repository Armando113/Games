using UnityEngine;
using System.Collections;

public class PlayerNode : GameObjectNode
{
    public PlayerNode() : base(BaseType.PLAYER)
    {

    }

    // Use this for initialization
    void Start ()
    {
        //New tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/PlayerTree"), new Vector3(), new Quaternion());
        nuObj.transform.parent = this.transform;
        myTree = nuObj.GetComponent<PlayerTree>();
    }
}
