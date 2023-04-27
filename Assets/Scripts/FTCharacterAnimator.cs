using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTCharacterAnimator : MonoBehaviour
{
    public enum FTCharacterAnimation { IDLE, MOVE_NORTH, MOVE_SOUTH, MOVE_NORTHEAST, MOVE_NORTHWEST, MOVE_SOUTHEAST, MOVE_SOUTHWEST }
    [SerializeField] Animator animator;
    [SerializeField] FTCharacter character;

    private void Start()
    {
        character.startedMoving += handleStartedMoving;
        character.moved += handleMoved;
        animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
    }

    public Dictionary<Direction, FTCharacterAnimation> directionToAnimation = new Dictionary<Direction, FTCharacterAnimation>() {
        {Direction.NORTH, FTCharacterAnimation.MOVE_NORTH},
        {Direction.SOUTH, FTCharacterAnimation.MOVE_SOUTH},
        {Direction.NORTHEAST, FTCharacterAnimation.MOVE_NORTHEAST},
        {Direction.NORTHWEST, FTCharacterAnimation.MOVE_NORTHWEST},
        {Direction.SOUTHEAST, FTCharacterAnimation.MOVE_SOUTHEAST},
        {Direction.SOUTHWEST, FTCharacterAnimation.MOVE_SOUTHWEST},
    };
    void handleStartedMoving(Direction dir)
    {
        PlayAnimation(directionToAnimation[dir]);
    }

    void handleMoved(Direction dir)
    {
        animator.Play("idle");
    }

    public void PlayAnimation(FTCharacterAnimation animation)
    {
        switch (animation)
        {
            case FTCharacterAnimation.IDLE:
                animator.Play("idle");
                break;
            case FTCharacterAnimation.MOVE_NORTH:
                animator.Play("move_north");
                break;
            case FTCharacterAnimation.MOVE_SOUTH:
                animator.Play("move_south");
                break;
            case FTCharacterAnimation.MOVE_NORTHEAST:
                animator.Play("move_northeast");
                break;
            case FTCharacterAnimation.MOVE_NORTHWEST:
                animator.Play("move_northwest");
                break;
            case FTCharacterAnimation.MOVE_SOUTHEAST:
                animator.Play("move_southeast");
                break;
            case FTCharacterAnimation.MOVE_SOUTHWEST:
                animator.Play("move_southwest");
                break;
        }
    }
}
