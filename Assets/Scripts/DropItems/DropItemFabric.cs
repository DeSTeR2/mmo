using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Fabric.DropItem {

    public class DropItem {
        private string Name;
        private int Value;

        
        public DropItem(string name, int value) {
            Name = name;
            Value = value;
        }

        public DropItem(DropItem dropItem) {
            if (dropItem == null) {
                Debug.Log("Null drop item");
                return;
            }
            Name = dropItem.getName();
            Value = dropItem.getValue();
        }

        public int getValue() {
            return Value;
        }

        public string getName() {
            return Name;
        }
    }


}