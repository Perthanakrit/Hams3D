using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathSys_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    #region Private
    [SerializeField] private EnemyStats stats;
    private float currenthealth;
    private GameObject player;
    private Animator animator;
    #endregion
    [Header("Camera Shaker")]
    [Range(0, 10)]
    public float amplitude;
    [Range(0, 2)]
    public float frquency;

    [HideInInspector]
    public float idEnemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        currenthealth = stats.Hp;
        idEnemy = gameObject.GetInstanceID();
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //print(true);
            player = collision.gameObject;
        }
    }
    public void TakeDamage(float damageAmount)
    {
        currenthealth -= damageAmount;
        animator.SetTrigger("damage");
        //_healthBar.UpdateHealthBar(maxhealth, currenthealth);
        cameraShake.Instance.ShakeCamera(amplitude, frquency);
        //CameraShake.Instance.ShakeCamera(2f, 0.2f);

    }

    void Die()
    {
        //dead = true;
        //Instantiate(ragdoll, transform.position, transform.rotation);
        erika_Combat.Instance.WhichEnemyDead(idEnemy);
        Destroy(this.gameObject);
    }
}
