using UnityEngine;
using System.Collections;



/*
 * Item class. ALL values will be set when item is created. Only count will be changed after creation.
 */
public class Item : MonoBehaviour {

    //Item stats
    private string m_name;
    private int m_id;
    private int m_count;
    private int m_powerCount;
    private int m_powerUpID;

    /*
     * Constructor
     * 
     * id: INT id for item
     * name: STRING name of item
     * countForPowerup:  INT number of items needed for powerup
     * powerupID: ID of powerup item.
     */
    public Item(int id, string name, int countForPowerup, int powerupID) {
        m_id = id;
        m_name = name;
        m_powerCount = countForPowerup;
        m_count = 0;
        m_powerUpID = powerupID;
    }

    //same as above, removing powerups for collectables
    public Item(int id, string name)
    {
        m_id = id;
        m_name = name;
        m_powerCount = 100;
        m_count = 0;
        m_powerUpID = -1;
    }

    //Getters
    public int getID(){
        return m_id;
    }
    public string getName() {
        return m_name;
    }
    public int getCount() {
        return m_count;
    }

    /* Not In Use:  this code is for using collections to give powerups
     *              Or other items (just a concept)
     * 
     * This will return an item id if the powerup is granted.
     * it will return -1 if there isnt enough items collected
     */
    public int getPowerup()
    {
        if (m_powerCount < m_count)
        {
            m_count -= m_powerCount;
            return m_powerUpID;
        }
        else
        {
            return -1;
        }
    }

    public void setCount(int count) {
        m_count = count;
    }
    public void incrementCount() {
        m_count++;
    }
    public void decrementCount() {
        m_count--;
    }

}
