using System.Collections.Generic;

public class Inventory
{
    static List<string> inventory = new List<string>();

    public static void addItem(string itemName){
        inventory.Add(itemName);
    }

    public static bool hasItem(string itemName){
        return inventory.Contains(itemName);
    }
}
