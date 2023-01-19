using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectible
{
    [System.Serializable]
    public class Dropped
    {
        public GameObject prefab;
        [Range(0f, 100f)]
        public float Chance = 100f;
        [HideInInspector] public double _weight;
    }

    public class Spawning : MonoBehaviour
    {
        [SerializeField] private GameObject collectible_mana;
        [SerializeField] List<Dropped> m_Dropped = new List<Dropped>();
        [SerializeField] int MaxClone;
        int prefabCount;

        private double accumulatedWeights;
        private System.Random rand = new System.Random();

        public void SpawnCollectible(Transform pointEnemy)
        {
            CalculateWeights();
            //GameObject clone = Instantiate(collectible_mana, pointEnemy.position + new Vector3(0,2f, 1f), pointEnemy.rotation);
            //GameObject clone1 = Instantiate(m_Dropped[0].prefab, pointEnemy.position + new Vector3(0, 2f, 2f), pointEnemy.rotation);
            
            for (int i = 0; i < m_Dropped.Count; i++)
            { 
                RandomDropping(pointEnemy.position + new Vector3(Random.Range(0f, 1f), 2f, Random.Range(0f, 1.5f)), pointEnemy.rotation);  
            }
            //clone.GetComponent<SphereCollider>().enabled = false;
            //StartCoroutine(Droping(clone));
            //var rb = clone.GetComponent<Rigidbody>();
            //rb.AddForce(clone.transform.up * 10f, ForceMode.Force);
            
        }
        /*private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) 
            { 
                other.gameObject.GetComponent<scaleCharacter>()._character.CharacterExp = collectiblesvalue.exp;
                other.gameObject.GetComponent<ManaSystem>().currentMana += collectiblesvalue.mana;
            }
        }*/
        void RandomDropping(Vector3 position, Quaternion rotation)
        {
            Dropped randomprefab = m_Dropped[GetRandomEnemyIndex()];
            GameObject prefab = m_Dropped[Random.Range(0, m_Dropped.Count)].prefab;
            GameObject clone = Instantiate(prefab, position, rotation);

            Debug.Log("Chance" + randomprefab.Chance);
        }

        private int GetRandomEnemyIndex()
        {
            double r = rand.NextDouble() * accumulatedWeights;

            for (int i = 0; i < m_Dropped.Count; i++)
            {
                if (m_Dropped[i]._weight >= r) return i;
            }
            return 0;
        }
        private void CalculateWeights()
        {
            accumulatedWeights = 0f;
            foreach (Dropped drop in m_Dropped)
            {
                accumulatedWeights += drop.Chance;
                drop._weight = accumulatedWeights;
            }
        }
    }
}