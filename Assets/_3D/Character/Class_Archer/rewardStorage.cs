using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectible
{
    [CreateAssetMenu(menuName = "Character/reward")]
    public class rewardStorage : ScriptableObject
    {
        public float exp { get; set; }
        public int coin { get; set; }

        public float mana;
    }
}