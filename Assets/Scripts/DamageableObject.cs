using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageableObject : MonoBehaviour
{
    public abstract HealthSystem GetHealthSystem();
}
