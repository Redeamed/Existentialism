using UnityEngine;
using System.Collections;
using System.Linq;


public class scrNode : MonoBehaviour {

    //public bool preset = false;

    public bool hasEntered = false;
    bool hasTraps = false;
    bool hasCollectable = false;
    bool hasPowerUp = false;
    bool isExit = false;

    GameObject[] traps;
    GameObject pickUpItem;
    GameObject[] neighbors;

    int rightPath = -1;
    public void Awake()
    {
        FindTraps();
        Transform[] arrayOfChildren = transform.Cast<Transform>().Where(c => c.gameObject.tag == "NeighborSpawn").ToArray();
        neighbors = new GameObject[arrayOfChildren.Length];
        for (int i = 0; i < neighbors.Length; ++i)
        {
            neighbors[i] = null;
        }
    }
    public bool CheckEntered(){ return hasEntered;}
    public GameObject[] GetTraps() { return traps; }
    void FindTraps()
    {
        GameObject[] tempArray = new GameObject[transform.childCount];
        int trapCount = 0;
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform temp = transform.GetChild(i);
            if (temp.tag == "Trap")
            {
                tempArray[trapCount] = temp.gameObject;
                trapCount++;
            }
        }
        if (trapCount <= 0)
        {
            GameObject[] result = new GameObject[trapCount];
            for (int i = 0; i < trapCount; ++i)
            {
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") hasEntered = true;
    }

    public GameObject[] GetNeighbors()
    {
        return neighbors;
    }
}
