using UnityEngine;
using System.Collections;
using System;

public class BirdTree : TreeComposite
{

    public BirdTree() : base(GameObjectType.OBSTACLE)
    {

    }

    // Use this for initialization
    void Start()
    {
        //Create the Coin
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Obstacle/Bird"), new Vector3(), new Quaternion());
        //Make it our transform's child
        tObj.transform.parent = this.transform;
        //Get the Coin Script
        Birds tBird = tObj.GetComponent<Birds>();

        tObj.SetActive(false);
        //Add it to our active list
        AddReserveChild(tBird);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Birds GetBird()
    {
        return (Birds)pActiveChildHead;
    }

    public override void Activate()
    {

    }

    public override void Deactivate()
    {

    }

    public override void Row(Vector3 _target)
    {

    }
}
