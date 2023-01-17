using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cooldowns
{
    public class TestAbility : MonoBehaviour, IHasCooldown
    {
        [Header("References")]
        [SerializeField] private Transform prefabSpawnPoint = null;
        [SerializeField] private GameObject projectilePrefab = null;
        [SerializeField] private CooldownSystem cooldownSystem;

        [Header("Settings")]
        [SerializeField] private int id = 1;
        [SerializeField] private float cooldownDuration = 5f;

        public int Id => id;
        public float CooldownDuration => cooldownDuration;

        private void Start()
        {
            cooldownSystem = this.GetComponent<CooldownSystem>();
        }

        private void Update()
        {
            if (!Keyboard.current.spaceKey.wasPressedThisFrame) { return; }

            if(cooldownSystem.IsOnCooldown(Id)) { return; }

            GameObject projectileInstance = Instantiate(projectilePrefab, prefabSpawnPoint.position, prefabSpawnPoint.rotation);

            if(projectileInstance.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.AddForce(projectileInstance.transform.forward * 5, ForceMode.VelocityChange);
            }

            cooldownSystem.PutOnCooldown(this);
        }

    }
}
