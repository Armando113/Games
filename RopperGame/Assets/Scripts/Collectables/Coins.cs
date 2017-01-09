using UnityEngine;
using System.Collections;

public class Coins : TreeLeaf
{
    protected float threshold;

    public Coins() : base(GameObjectType.ITEM)
    {
        threshold = 0.1f;
    }

    // Use this for initialization
    void Start()
    {
        mySprite = this.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRowing)
        {
            //Move in X
            if (targetPos.x != this.transform.position.x)
            {
                this.transform.position = new Vector3(targetPos.x, this.transform.position.y, this.transform.position.z);
            }

            if (targetPos.y == this.transform.position.y || this.transform.position.y < (targetPos.y + threshold))
            {
                //Set the position to the target
                this.transform.position = targetPos;

                isRowing = false;
            }
            else if (targetPos.y < this.transform.position.y)
            {
                //Move to target
                this.transform.position = Vector3.Lerp(this.transform.position, targetPos, GameRules.GetGlobalSpeed());
            }
            else
            {
                //This means that we have reached the bottom
                //Move to target
                this.transform.position = targetPos;

                //We are no longer rowing
                isRowing = false;
            }

        }
    }
    public override void Activate()
    {

    }

    public override void Deactivate()
    {

    }
}


