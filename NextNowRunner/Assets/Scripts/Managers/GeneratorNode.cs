using UnityEngine;
using System.Collections;

public class GeneratorNode : GameObjectNode
{

    public GeneratorNode() : base(BaseType.GENERATOR)
    {

    }

	// Use this for initialization
	void Start ()
    {
        //New tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/GeneratorTree"), new Vector3(), new Quaternion());
        nuObj.transform.parent = this.transform;
        myTree = nuObj.GetComponent<GeneratorTree>();
    }
	
}
