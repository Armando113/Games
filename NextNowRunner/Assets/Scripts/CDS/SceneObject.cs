using UnityEngine;
using System.Collections;

abstract public class SceneObject : TreeLeaf
{

    protected SceneObject(BaseType _type) : base(_type)
    {

    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Highly requested function!
    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
