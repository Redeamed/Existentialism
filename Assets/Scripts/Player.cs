using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Sanity Related variables
    [SerializeField] private float sanity;          //Value to represent "health" 0=death
    [SerializeField] private bool inDarkness;       //If the player is in Darkness
    [SerializeField] private float sanityDimRate;   //The rate at which sanity diminishes
    [SerializeField] private float sanityRiseRate;  //The at which sanity rises

    //Trap impairment variables
    [SerializeField] private float isCrippleduration; //Duration of Cripple effects
    [SerializeField] private bool isCrippled;         //If player is isCrippled
    [SerializeField] private float crippleStamp;    //Time crippled
    [SerializeField] private float stopDuration;    //Duration of stop effects
    [SerializeField] private float stopStamp;       //Time stopped
    [SerializeField] private bool isStopped;          //If player is stopped

    //Sprinting System Variables
    [SerializeField] private float stamina;         //Value for sprinting
    [SerializeField] private bool recovering;       //If player has exhausted stamina and is sprinting
    [SerializeField] private float recoverStamp;    //When the player started recovering
    [SerializeField] private float recoverDuration; //How long the player spends recovering

    //Reference variables
    [SerializeField] private Movement movement;     //Refrence to movement script for disabling movement
    [SerializeField] private GameObject currentTile;//Reference to what tile the player currently is in
    [SerializeField] private TileLighting currentTileLighting;  //Reference to what the tilelighting script attached to the tile the player currently is in



    void Awake()
    {
        movement = GetComponent<Movement>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        sprinting();
        sanityCheck();
	}

    void sprinting()            
    {
        if (!recovering)        //If player isnt recovering and out of stamina, record time started recovering                
        {
            if (stamina <= 0)
            {
                recovering = true;               
                recoverStamp = Time.time;
            }
        }
        if (!recovering)        //If player isnt recovering and has less than 100 stamina, gain stamina
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                if (stamina < 100)
                {
                    stamina += 4.5f * Time.deltaTime;
                }
            }            
        }
        if (recovering)         //If player is recovering and set stamina to N and end recovering
        {
            if (Time.time - recoverStamp > recoverDuration)
            {
                recovering = false;
                stamina = 5;
            }
        }
        if (!recovering)        //If player isnt recovering and is holding left shift, sprint
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                stamina -= 10 * Time.deltaTime;
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!isStopped)
                {
                    movement.sprint();
                    if (isCrippled)
                    {
                        movement.cripple();
                    }
                }
            }
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (!isStopped)
                {
                    movement.resetSpeed();
                    if (isCrippled)
                    {
                        movement.cripple();
                    }
                }
            }
        } 
        if(isCrippled)
        {
            if(Time.time - crippleStamp > isCrippleduration)
            {
                isCrippled = false;
            }
        }    
        if(isStopped)
        {
            if(Time.time - stopStamp > stopDuration)
            {
                isStopped = false;
            }
        }   
    }

    void cripplePlayer()
    {
        isCrippled = true;
        crippleStamp = Time.time;
    }

    void stopPlayer()
    {
        isStopped = true;
        stopStamp = Time.time;
    }

    void sanityCheck()
    {
        if (currentTileLighting != null)
        {
            if (currentTileLighting.getDark())
            {
                inDarkness = true;
            }
            else
            {
                inDarkness = false;
            }
        }
        //Delete later
        if(currentTileLighting == null)
        {
            inDarkness = false;
        }
        if(sanity <=0)
        {
            sanity = 0;
            //dead
        }
        if(inDarkness)
        {
            sanity -= sanityDimRate*Time.deltaTime;
        }
        if(!inDarkness)
        {
            if (sanity < 100)
            {
                sanity += sanityRiseRate * Time.deltaTime;
            }
        }
        if(sanity > 100)
        {
            sanity = 100;
        }
    }
    public void setTileReferences(GameObject tile, TileLighting tl)
    {
        currentTile = tile;
        currentTileLighting = tl;
    }
}
