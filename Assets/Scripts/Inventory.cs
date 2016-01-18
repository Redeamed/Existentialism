using UnityEngine;
using System.Collections;
using System;

public class Inventory : MonoBehaviour {
    //This will contain all item types
    private ArrayList index = new ArrayList();
    private int currentIndex = 0;

    /* Add Item, will allow any other object to add to the list of things
     * returns the item ID (so you can save it in your object).
     * 
     * Does not allow for duplicate items
     * 
     * TODO: add check to see if item exists, if it does, return that item ID
     *      (not in for performance reasons... large loop)
    */
    public int addItem(string name) 
    {
        for (int i = 0; i < currentIndex; i++)
        {
            if ((index[i] as Item).getName() == name) 
            {
                return (index[i] as Item).getID();
            }
        }

        int id = currentIndex++;
        index.Add(new Item(id, name));
        return id;
    }

    /*
     * return an item from the index by its ID number
     * 
     * On invalid index will return an item with ID equal to -1
    */
    public Item getItemByID(int id) 
    {
        Item item;
        try
        {
            item  = index[id] as Item;
        }
        catch (Exception e)
        {
            Debug.Log("Error: Inventory - " + e);
            return new Item(-1, "Invlaid Item");
        }

        return item;
    }
}
