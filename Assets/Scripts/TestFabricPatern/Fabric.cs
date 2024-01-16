using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

namespace Factory
{
    public abstract class Ability {
        public abstract string Name { get; }

        public abstract void Process(GameObject target, int amound);
    }

    public class Heal : Ability {
        public override string Name => "heal";
        
        public override void Process(GameObject target, int amound) {
            int health = (int)(Variables.Object(target).Get("Health"));
            health += amound;
            Variables.Object(target).Set("Health", health);

        }
    }

    public class Damage : Ability {
        public override string Name => "damage";

        public override void Process(GameObject target, int amound) {
            target?.GetComponent<AtackWeapon>()?.Atack();

        }
    }

    public class AddExp : Ability {
        public override string Name => "addExp";

        public override void Process(GameObject target, int amound) {
            int exp = (int)(Variables.Object(target).Get("Exp"));
            exp += amound;
            Variables.Object(target).Set("Exp", exp);
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
