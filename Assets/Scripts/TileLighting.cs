using UnityEngine;
using System.Collections;

public class TileLighting : MonoBehaviour {

    /*
        Lights act as the main focus of danger for the player
        When a player enters a tile the light triggers and begins to dim
        Once light hits a certain point it begins to "damage the player"
        Interesting things to consider:
            Different types of lights
            Different colors of lights
            Other neat lighting effects.
    */
    public GameObject player;                   //Reference to the player
    [SerializeField]private Light light;        //Reference to the light attached to this GameObject
    [SerializeField]private float maxLight;     //Max Light luminence
    [SerializeField]private float minlight;     //Min Light luminence
    [SerializeField]private float dimRate=1;      //Speed at which the light dims
    [SerializeField]private bool triggered;     //Boolean check triggered when player has entered the tile.
    
    //Testing Variables
    

    void Awake()
    {
        //Find Reference to the light
        light = transform.FindChild("TileLight").gameObject.GetComponent<Light>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        triggerLight();
	}

    //Method for when the player enters the tile
    public void triggerLight()
    {
        //triggered = true;
        //if(!triggered)
        //{
            InvokeRepeating("dimLight", .1f, dimRate);
       // }
    }

    void dimLight()
    {
        light.intensity -= .003f;
    }

    //Method for damaging the player
    void blackout()
    {
        //player.damage
    }

    public bool getTriggered()
    {
        return triggered;
    }
}
