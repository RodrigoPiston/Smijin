using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/DemonSoulBall", order = 2)]
public class DemonSoulBallAbility : Ability
{
    [SerializeField] private float damage = 20f;

    public override void Activate(GameObject parent)
    {
        Debug.Log("Demon soul activated");
    }

    public override void BeginCooldown(GameObject parent)
    {
    }
}
