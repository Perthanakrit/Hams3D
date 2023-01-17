using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _healthbarSprite;
    [SerializeField] float _reduceSpeed = 2;
    [SerializeField] bool NotBoss;
    
    private Camera _camera;
    private float _target = 1;

    void Start()
    {
        _camera = Camera.main;
    }
    public void UpdateHealthBar(float maxhealth, float currenthealth)
    {
        _target = currenthealth / maxhealth;
    }

    void Update()
    {
        if(NotBoss) transform.rotation = Quaternion.Euler(315f,135f,0f);
        _healthbarSprite.fillAmount = Mathf.MoveTowards(_healthbarSprite.fillAmount, _target, _reduceSpeed * Time.deltaTime);
    }
}
