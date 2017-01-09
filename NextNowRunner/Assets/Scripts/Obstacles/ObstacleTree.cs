using UnityEngine;
using System.Collections;

public class ObstacleTree : TreeComposite
{
    public ObstacleTree() : base(BaseType.OBSTACLE)
    {

    }

    // Use this for initialization
    void Start ()
    {
	
	}

    public RedWall GetRedWall()
    {
        RedWall wall = (RedWall)PopReserveChild();

        if (wall == null)
        {
            GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/RedWall"), new Vector3(), new Quaternion());
            wall = nuObj.GetComponent<RedWall>();
            nuObj.transform.parent = this.transform;
        }
        //Set active
        wall.gameObject.SetActive(true);
        //Add Active
        AddActiveChild(wall);

        return wall;
    }

    public void ReturnRedWall(RedWall _wall)
    {
        if (FindActive(_wall) == null)
        {
            return;
        }

        //Remove from active
        RemoveActiveChild(_wall);
        //Deactivate
        _wall.gameObject.SetActive(false);
        //add to active
        AddReserveChild(_wall);
    }
}
