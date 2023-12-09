using UnityEngine;

public class HealthSystemTest : MonoBehaviour
{
    public HealthSystem hSystem;
    public float DamageValue;
    public float HealValue;
    public float AutoHealValue;
    public float AutoHealPeriod;

    [ContextMenu("CreateDamage")]
    public void CreateDamage()
    {
        hSystem.GetDamage(DamageValue);
    }

    [ContextMenu("AddHealth")]
    public void AddHealth()
    {
        hSystem.AddHealth(HealValue);
    }

    [ContextMenu("Revive")]
    public void Revive()
    {
        hSystem.OnRevival();
    }

    [ContextMenu("AutoHealParams")]
    public void SetAutoHeal()
    {
        hSystem.SetAutoHealPeriod(AutoHealPeriod);
        hSystem.SetAutoHealValue(AutoHealValue);
    }

}
