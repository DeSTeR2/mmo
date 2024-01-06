using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fabric.DropItem;

public class DropItemLogic : MonoBehaviour
{
    public string Name;
    public int Amound;
    public void setDropItem(DropItem dropItem) {
        Name = dropItem.getName();
        Amound = dropItem.getValue();
    }

    public DropItem getDropItem() {
        return new DropItem(Name, Amound);        
    }
}
