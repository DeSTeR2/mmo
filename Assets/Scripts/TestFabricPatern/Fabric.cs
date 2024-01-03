using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    public abstract class Ability {
        public abstract string Name { get; }

        public abstract void Process(GameObject target);
    }

    public class Heal : Ability {
        public override string Name => "heal";
        
        public override void Process(GameObject target) {
            float health = (float)(Variables.Object(target).Get("Health"));
            health += 10;
            Variables.Object(target).Set("Health", health);
            //self.health += 10;
            Debug.Log("healed");
        }
    }

    public class Damage : Ability {
        public override string Name => "damage";

        public override void Process(GameObject target) {
            float mana = (float)(Variables.Object(target).Get("Mana"));
            mana -= 10;
            Variables.Object(target).Set("Mana", mana);
            Debug.Log("damaged");
        }
    }

    public class AbilityFactory {
        Dictionary<string, Type> abilities;

        public AbilityFactory() {
            var abilityTypes = Assembly.GetAssembly(typeof(Ability)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Ability)));

            abilities = new Dictionary<string, Type>();
            
            foreach (var abiliti in abilityTypes) {
                var temp = Activator.CreateInstance(abiliti) as Ability;
                abilities.Add(temp.Name, abiliti);
            }
        }

        public Ability GetAbility(string name) {
            if (abilities.ContainsKey(name)) {
                Type type = abilities[name];
                var ability = Activator.CreateInstance(type) as Ability;
                return ability;
            } else return null;
        }

        internal Dictionary<string, Type> GetAllNames() {
            return abilities;
        }
    }
}
