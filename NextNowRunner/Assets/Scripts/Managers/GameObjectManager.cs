using UnityEngine;
using System.Collections;

public class GameObjectManager : Manager
{

    private static GameObjectManager pInstance;

    private GameObjectManager()
    {
        //The player tree
        GameObject nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/PlayerNode"), new Vector3(), new Quaternion());
        GameObjectNode nuNode = nuObj.GetComponent<PlayerNode>();
        AddActive(nuNode);
        //The floor tree
        nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/FloorNode"), new Vector3(), new Quaternion());
        nuNode = nuObj.GetComponent<FloorNode>();
        AddActive(nuNode);
        //Generators
        nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/GeneratorNode"), new Vector3(), new Quaternion());
        nuNode = nuObj.GetComponent<GeneratorNode>();
        AddActive(nuNode);
        //Item
        nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/ItemNode"), new Vector3(), new Quaternion());
        nuNode = nuObj.GetComponent<ItemNode>();
        AddActive(nuNode);
        //Obstacle
        nuObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/ObstacleNode"), new Vector3(), new Quaternion());
        nuNode = nuObj.GetComponent<ObstacleNode>();
        AddActive(nuNode);


    }

    private static GameObjectManager GetInstance()
    {
        if (pInstance == null)
        {
            pInstance = new GameObjectManager();
        }
        return pInstance;
    }

    public static TreeComponent GetTree(BaseType _type)
    {
        //Set he iterator
        GetInstance().pIterator.SetNode(GetInstance().pActiveHead);

        while (GetInstance().pIterator.GetNode() != null)
        {
            if (GetInstance().pIterator.GetNode().GetBaseType().Equals(_type))
            {
                //Found it!!
                GameObjectNode tNode = (GameObjectNode)GetInstance().pIterator.GetNode();

                return tNode.GetTree();
            }
            //Keep Walking Johnny
            GetInstance().pIterator.GoNext();
        }

        return null;
    }

    public static void Activate()
    {
        GetInstance().pIterator.SetNode(GetInstance().pActiveHead);

        while(GetInstance().pIterator.GetNode() != null)
        {
            //Activate
            GameObjectNode node = (GameObjectNode)GetInstance().pIterator.GetNode();
            node.Activate();
            //Keep walking johnny
            GetInstance().pIterator.GoNext();
        }
    }

    public static void Deactivate()
    {
        GetInstance().pIterator.SetNode(GetInstance().pActiveHead);

        while (GetInstance().pIterator.GetNode() != null)
        {
            //Activate
            GameObjectNode node = (GameObjectNode)GetInstance().pIterator.GetNode();
            node.Deactivate();
            //Keep walking johnny
            GetInstance().pIterator.GoNext();
        }
    }

    public static void Kickstart()
    {
        GetInstance();
    }

    public static void DumpActive()
    {
        GetInstance().DumpActiveNodes();
    }

}
