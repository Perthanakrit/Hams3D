using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Character/Skill")]
public class skills_Scriptable : ScriptableObject
{
    [Header("Infomation Skill")]
    public GameObject skill;
    public int Id;
    public Sprite image;
    public float damage;
    public float cooldown;
    public float manavalue;

    [Header("Processing")]
    public bool canActivate;
    public float fakeTime = 0;
    //public float countDown = 0.175f;
    public IEnumerator CooldownAbility(float cooldown)
    {
       // countDown += 1 * Time.deltaTime;
        yield return new WaitForSeconds(cooldown);
        //countDown = 0.175f;
        canActivate = true;
    }
}
