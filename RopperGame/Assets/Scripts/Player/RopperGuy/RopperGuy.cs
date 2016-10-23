using UnityEngine;
using System.Collections;
using System;

public class RopperGuy : TreeLeaf
{

    //Ropper guy has energy (He ain't Mario after all :P)
    public RopperEnergy myEnergy;

    private RopperAnimator myAnim;

    //Threshold
    private float threshold;

    public RopperGuy() : base(GameObjectType.PLAYER)
    {
        threshold = 0.1f;
    }

    // Use this for initialization
    void Start ()
    {
        mySprite = this.GetComponentInChildren<SpriteRenderer>();

        myAnim = new RopperAnimator(this.GetComponentInChildren<Animator>());

        myEnergy = new RopperEnergy(myAnim);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FixedUpdate()
    {
        if (isRowing)
        {
            if (targetPos.x == this.transform.position.x || this.transform.position.x < (targetPos.x + threshold))
            {
                //Set the position to the target
                this.transform.position = targetPos;

                isRowing = false;
            }
            else if (targetPos.x < this.transform.position.x)
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

    public void DrainEnergy(float _amount)
    {
        myEnergy.DrainEnergy(_amount);
    }

    public void AddEnergy(float _amount)
    {
        myEnergy.RecoverEnergy(_amount);
    }

    public void ResetEnergy()
    {
        myEnergy.ResetEnergy();
    }

    public void Animate(int _index)
    {
        if(myAnim == null)
        {
            myAnim = new RopperAnimator(this.GetComponentInChildren<Animator>());
        }
        myAnim.Animate(_index);
    }
    public void Animate(string _myanimName)
    {
        if (myAnim == null)
        {
            myAnim = new RopperAnimator(this.GetComponentInChildren<Animator>());
        }
        myAnim.Animate(_myanimName);
    }


    public override void Activate()
    {
        
    }

    public override void Deactivate()
    {
        
    }
}
