using UnityEngine;

namespace Cooldowns_Per
{
    public interface IHasCooldown
    {
        int Id { get; }
        float CooldownDuration { get; }
    }
}