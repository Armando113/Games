using UnityEngine;
using System.Collections;

public class Coin : SceneObject
{

    private float rotateVect;

    public Coin() : base(BaseType.ITEM)
    {
        rotateVect = 100.0f;
    }

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        this.transform.Rotate(0.0f, rotateVect * Time.deltaTime, 0.0f);
    }
}
