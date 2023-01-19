using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectible
{
    [CreateAssetMenu(menuName = "Collectible/Enemy")]
    public class CollectibleSpawning : ScriptableObject
    {
        public float exp;
        public float mana;
        public float Hp;
        public int coin;
    }

}