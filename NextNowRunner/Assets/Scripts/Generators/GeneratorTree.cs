using UnityEngine;
using System.Collections;

public class GeneratorTree : TreeComposite
{
    public GeneratorTree() : base(BaseType.GENERATOR)
    {

    }

    // Use this for initialization
    void Start ()
    {
        //Create the generators
        if (pReserveHead == null)
        {
            //Floor
            GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/FloorGenerator"), new Vector3(), new Quaternion());
            FloorGenerator fGen = nuObj.GetComponent<FloorGenerator>();
            nuObj.transform.parent = this.transform;
            nuObj.SetActive(false);
            AddReserveChild(fGen);
            //Item
            nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/CoinGenerator"), new Vector3(), new Quaternion());
            CoinGenerator cGen = nuObj.GetComponent<CoinGenerator>();
            nuObj.transform.parent = this.transform;
            nuObj.SetActive(false);
            AddReserveChild(cGen);
            //Obstacles
            nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/WallGenerator"), new Vector3(), new Quaternion());
            WallGenerator wGen = nuObj.GetComponent<WallGenerator>();
            nuObj.transform.parent = this.transform;
            nuObj.SetActive(false);
            AddReserveChild(wGen);
        }
    }

    public override void ActivateObject()
    {

        while (pReserveHead != null)
        {
            SceneObject obj = (SceneObject)PopReserveChild();
            //Set active
            obj.gameObject.SetActive(true);
            //Actually Activate!
            obj.ActivateObject();
            AddActiveChild(obj);
        }
    }

    public override void DeactivateObject()
    {
        while (pActiveHead != null)
        {
            SceneObject obj = (SceneObject)pActiveHead;
            //Set active
            obj.gameObject.SetActive(false);
            obj.DeactivateObject();
            RemoveActiveChild(obj);
            AddReserveChild(obj);
        }
    }
}
