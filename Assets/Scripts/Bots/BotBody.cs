using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BotBody : MonoBehaviour
{
    Animator animator;

    public void Init(RobotType robotType)
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Type", (int)robotType);
    }
}
