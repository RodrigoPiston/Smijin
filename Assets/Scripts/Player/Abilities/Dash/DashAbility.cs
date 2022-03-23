using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Dash", order = 1)]
public class DashAbility : Ability
{
    [SerializeField] private float dashVelocity = 20f;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        movement.SetSpeed(dashVelocity); 
        parent.GetComponent<PlayerMovement>().SetTrailDashState(true);
    }

    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        movement.SetSpeed(movement.GetNormalSpeed());
        parent.GetComponent<PlayerMovement>().SetTrailDashState(false);
    }
}
