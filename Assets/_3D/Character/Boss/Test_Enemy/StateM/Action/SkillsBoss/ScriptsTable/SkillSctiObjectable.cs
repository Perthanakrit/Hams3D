using UnityEngine;

[CreateAssetMenu(menuName ="Skills/baseStats")]
public class SkillSctiObjectable : ScriptableObject
{
    public ScriptableObject skillsScriptable;
    public float Cooldown = 10f;
    public float Damage = 5;
    public int Unlocklevel = 1;

    public bool IsActiveing;

    protected float UseTime;

   /* public virtual SkillSctiObjectable ScaleUpForLevel(ScalingSctiObjectable scaling, int level)
    {
        
    }*/


}
