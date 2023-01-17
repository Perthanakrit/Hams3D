using UnityEngine;

namespace Cooldowns
{
    public interface IHasCooldown
    {
        int Id { get; }
        float CooldownDuration { get; }
    }
}