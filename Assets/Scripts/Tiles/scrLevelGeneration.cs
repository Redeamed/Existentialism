using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scrLevelGeneration : MonoBehaviour {
    public const float SNAP = 10;
    public const int PATHBASE = 4;
    //default 0 is the preset level state. do not generate a level he first time.
    public int currentLevel = 1;
    public GameObject[] presetLevels;
    public bool generate = false;
    //total nodes from start to end
    public int pathLength = 0;
    public float nextLevelOffset = 100.0f;

    string[] tilePaths;
    scrNode[][] Maze;

	// Use this for initialization
	void Start ()
    {
        

        tilePaths = new string[5];
        tilePaths[0] = TileUtilities.deadEnd;
        tilePaths[1] = TileUtilities.corner;
        tilePaths[2] = TileUtilities.hall;
        tilePaths[3] = TileUtilities.oneWall;
        tilePaths[4] = TileUtilities.open;

        if (currentLevel < presetLevels.Length)
        {
            InitializeLevel(currentLevel);
        }
        else
        {
            GenerateLevel(currentLevel);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (generate) GenerateLevel(currentLevel);
	}

    void InitializeLevel(int value)
    {
        GameObject go = Instantiate(presetLevels[value]) as GameObject;
        go.transform.parent = this.transform;
        
    }

    void GenerateLevel(int value)
    {
        pathLength = PATHBASE * value;
        int tempLength = pathLength;

        List<GameObject> spawnpoints = new List<GameObject>();

        //spawn the firstnode.
        GameObject firstNode = SpawnNode(tilePaths[0]);
        GameObject[] sp = firstNode.GetComponent<scrNode>().GetNeighbors();
        foreach (GameObject go in sp)
        {
            spawnpoints.Add(go);
        }


    }

    GameObject SpawnNode(string path, int x = 0, int y = 0)
    {
        GameObject go = Resources.Load<GameObject>(path);//) as GameObject;
        go = Instantiate(go);
        go.transform.position = new Vector3(x * SNAP, 0, y * SNAP);
        go.transform.parent = this.transform;
        return go;
    }

}
