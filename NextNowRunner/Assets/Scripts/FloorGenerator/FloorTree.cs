using UnityEngine;
using System.Collections;
using System;

public class FloorTree : TreeComposite
{
    public FloorTree() : base(BaseType.FLOOR)
    {

    }

    public FloorBlock GetFloorBlock()
    {
        FloorBlock block = (FloorBlock)PopReserveChild();

        if(block == null)
        {
            GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/FloorBlock"), new Vector3(), new Quaternion());
            block = nuObj.GetComponent<FloorBlock>();
            nuObj.transform.parent = this.transform;
        }
        //Set Active
        block.gameObject.SetActive(true);
        //Add to active
        AddActiveChild(block);

        return block;
    }

    public void ReturnFloorBlock(FloorBlock _block)
    {
        if(FindActive(_block) == null)
        {
            Debug.LogError("Invalid block was passed! Watch your pointers dammit!! ò.ó");
            return;
        }
        //Remove from active
        RemoveActiveChild(_block);
        //Set inactive
        _block.gameObject.SetActive(false);
        //Add to reserve
        AddReserveChild(_block);
    }
}
