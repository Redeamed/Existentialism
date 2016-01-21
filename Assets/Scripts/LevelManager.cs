using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public Vector3 playerStart;
    public GameObject player;
    MazeGenerator mazeGen;
    public Vector2 initDimension;
    public int perLevel = 2;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log("LevelManager already exists in object: " + instance.gameObject.name);
            Destroy(this);
        }

        mazeGen = GetComponent<MazeGenerator>();
        mazeGen.RestartMaze((int)initDimension.x, (int)initDimension.y);
	}

    public void RestartMaze()
    {
        initDimension += Vector2.one * perLevel;
        mazeGen.RestartMaze((int)initDimension.x, (int)initDimension.y);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = playerStart;
    }
}
