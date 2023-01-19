using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown_forskill : MonoBehaviour
{
    public bool iscooldown1 = false;
    public bool iscooldown2 = false;
    public bool iscooldown3 = false;
    public bool iscooldown4 = false;
    public bool iscooldown5 = false;
    public bool iscooldown6 = false;
    public bool iscooldown7 = false;
    public bool iscooldown8 = false;
    public IEnumerator Cooldown1(float cooldowntime)
    {
        iscooldown1 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown1 = false;
    }
    public IEnumerator Cooldown2(float cooldowntime)
    {
        iscooldown2 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown2 = false;
    }
    public IEnumerator Cooldown3(float cooldowntime)
    {
        iscooldown3 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown3 = false;
    }
    public IEnumerator Cooldown4(float cooldowntime)
    {
        iscooldown4 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown4 = false;
    }
    public IEnumerator Cooldown5(float cooldowntime)
    {
        iscooldown5 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown5 = false;
    }public IEnumerator Cooldown6(float cooldowntime)
    {
        iscooldown6 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown6 = false;
    }
    public IEnumerator Cooldown7(float cooldowntime)
    {
        iscooldown7 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown7 = false;
    }
    public IEnumerator Cooldown8(float cooldowntime)
    {
        iscooldown8 = true;
        Debug.Log("cooldown");
        yield return new WaitForSeconds(cooldowntime);
        iscooldown8 = false;
    }
}
