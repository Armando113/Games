using UnityEngine;
using System.Collections;

public class Birds : TreeLeaf
{

    //Threshold
    private float threshold;

    //Default Constructor
    public Birds() : base(GameObjectType.OBSTACLE)
    {
        isRowing = false;
        targetPos = Vector3.zero;
        threshold = 0.1f;
    }


    // Use this for initialization
    void Start()
    {
        //Get the Sprite Renderer from the object
        mySprite = this.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRowing)
        {
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

    //Abstract Classes
    //Activate object
    public override void Activate()
    {
        this.gameObject.SetActive(true);
    }

    //Deactivate object
    public override void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}