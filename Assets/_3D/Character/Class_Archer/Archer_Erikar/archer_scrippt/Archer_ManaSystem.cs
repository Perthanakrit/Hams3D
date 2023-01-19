using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_ManaSystem : MonoBehaviour
{
    [SerializeField] float MaxMana = 100f;
    public float currentMana;
    [SerializeField] private HPManaHandler _Bar;
    [SerializeField] private CharacterList _character;

    void Start()
    {
        MaxMana = _character.mp;
        currentMana = MaxMana;
        _Bar = Camera.main.GetComponent<HPManaHandler>();
    }

    private void Update()
    {
        currentMana += (1f * Time.deltaTime);

        if (currentMana >= MaxMana) currentMana = MaxMana;

        if (currentMana <= 0f) currentMana = 0f;

        _Bar.UpdatManaBar(MaxMana, currentMana);
    }

    public void UseMana(float ManaCost)
    {
        Debug.Log("Use Mana");
        currentMana -= ManaCost;
    }
}
