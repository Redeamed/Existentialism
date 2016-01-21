using UnityEngine;
using System.Collections;

public class scrNodeEnd : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("RestartWorld", 5);
        }
    }
    IEnumerator RestartWorld()
    {

        LevelManager.instance.RestartMaze();
        return null;
    }
}


