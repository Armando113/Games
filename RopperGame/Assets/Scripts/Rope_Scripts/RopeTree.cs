using UnityEngine;
using System.Collections;

public class RopeTree : TreeComposite
{

	public RopeTree():base(GameObjectType.ROPE)
	{
		
	}

	// Use this for initialization
	void Start ()
    {
		//Create all Ropes here

		GameObject nuObj = (GameObject) MonoBehaviour.Instantiate(Resources.Load ("Prefabs/RopeBuilder/StrongBranch"), new Vector3 (), new Quaternion ());
		nuObj.transform.parent = this.transform;
		RopeBranch nuBranch = nuObj.GetComponent<StrongBranch>();
		nuObj.transform.parent = this.transform;
		AddActiveChild (nuBranch);
        nuObj = (GameObject) MonoBehaviour.Instantiate(Resources.Load ("Prefabs/RopeBuilder/WeakBranch"), new Vector3 (), new Quaternion ());
        nuObj.transform.parent = this.transform;
        nuBranch = nuObj.GetComponent<WeakBranch>();
        nuObj.transform.parent = this.transform;
        AddActiveChild(nuBranch);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Row(Vector3 _target)
	{
		//Set iterator
		pIterator.SetStartNode (pActiveChildHead);

		//Shout out to our nodes and yell Row.
		while (pIterator.GetNode() != null)
		{
			//Tell the current node to row.
			pIterator.GetNode().Row(_target);
			//Keep walking Johhny
			pIterator.GoNext();
		}
	}

	public override void Activate ()
	{

	}

	public override void Deactivate ()
	{

	}

    public RopeBranch GetBranch(RopeEnum _ropeType)
    {
        //Set iterator
        pIterator.SetStartNode(pActiveChildHead);

        //Walk the list and find the branch
        while(pIterator.GetNode() != null)
        {
            RopeBranch tBranch = (RopeBranch)pIterator.GetNode();

            if(tBranch.GetRopeType() == _ropeType)
            {
                return tBranch;
            }

            //Keep walking Johnny
            pIterator.GoNext();
        }

        //Everything went to hell .-.
        return null;
    }
}
