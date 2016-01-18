using UnityEngine;
using System.Collections;

public class ItemInWorld_Template : MonoBehaviour {
   
    string name = "Name Here";

    //DO NOT SET, will be set automatically (feel free to use though)
    int id;
    Inventory inv;
    //End do not touch


	// Use this for initialization
	void Start () {
        inv = new Inventory();
        id = inv.addItem(name);
	}


    void OnCollisionEnter() {
        inv.getItemByID(id).incrementCount();
        //trigger effect (ex give powerup ect...)
        Destroy(gameObject);
    }
}
