using UnityEngine;
using System.Collections;

public class TileFloor : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private GameObject tileSquare;          //Reference  to the empty gameobject parent
    [SerializeField] private TileLighting tileLighting;      //Reference to the tile light

    void Awake()
    {
        tileSquare = transform.parent.gameObject;
        tileLighting = tileSquare.GetComponent<TileLighting>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            player = col.gameObject.GetComponent<Player>();
            tileLighting.triggerLight();
            player.setTileReferences(gameObject, tileLighting);            
        }
    }
}
