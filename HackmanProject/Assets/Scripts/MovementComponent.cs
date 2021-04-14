using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : BaseGridObject
{
    public float MovementSpeed;
    protected IntVector2 targetGridPosition;
    protected IntVector2 currentInputDirection;
    protected IntVector2 previousInputDirection;
    protected float progressToTarget = 1f;


    private void Start()
    {
        targetGridPosition = GridPositon;
        MovementSpeed = 2;
    }

    protected virtual void Update()
    {
        //Check if we've arrived to the target position...
        if (transform.position == targetGridPosition.ToVector3())
        {
            progressToTarget = 0f;
            GridPositon = targetGridPosition;
        }

        //If we updated our grid position, and current input is valid...
        if (GridPositon == targetGridPosition
            && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirection.y),Mathf.Abs(targetGridPosition.x + currentInputDirection.x)] != 1)     
        {
            targetGridPosition += currentInputDirection;
            previousInputDirection = currentInputDirection;
        }

        //If we set a new target and previous input is valid...
        //For ghosts to turn around if they hit a wall, or the player if they are doing nothing
        else if(GridPositon == targetGridPosition
                && LevelGeneratorSystem.Grid[Mathf.Abs(targetGridPosition.y + previousInputDirection.y), Mathf.Abs(targetGridPosition.x + previousInputDirection.x)] != 1)
        {
            targetGridPosition += previousInputDirection;
        }
        if (GridPositon == targetGridPosition)
        {
            return;
        }
           
        progressToTarget += MovementSpeed * Time.deltaTime;
        transform.position =
            Vector3.Lerp(GridPositon.ToVector3(), targetGridPosition.ToVector3(), progressToTarget);
    }
}

public static class ExtensionMethods
{
    public static Vector3 ToVector3(this IntVector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y);
    }

    public static IntVector2 AsIntVector2(this Vector3 vector3)
    {
        return new IntVector2((int)vector3.x,(int)vector3.y);
    }
}
