using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotSpeed = 10f;

    public Animator animator;

    Vector3 startPos, desPos;
    Quaternion startRot, desRot;
    bool isMoving, isTurning = false;
    float fractionForPos, fractionForRot = 0;
           
    void Update()
    {
        Walk();

        if (isTurning)
        {
            Turn();
        }
    }

    private void Walk()
    {
        startPos = transform.position;
        if (Input.anyKeyDown && !isMoving && !isTurning)
        {
            desPos = transform.position;
            if (Input.GetKeyDown(KeyCode.W)) // Forward
            {
                desPos.x++;
                FindNewRotation(Vector3.forward);
                CheckShouldIncreaseScore(desPos.x);
            }
            else if (Input.GetKeyDown(KeyCode.S)) // Backward
            {
                desPos.x--;
                FindNewRotation(Vector3.back);
            }
            else if (Input.GetKeyDown(KeyCode.A)) // Left
            {
                desPos.z++;
                FindNewRotation(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.D)) // Right
            {
                desPos.z--;
                FindNewRotation(Vector3.right);
            }
            isMoving = true;
            animator.SetBool("isJumping", isMoving);
        }

        /*if (isMoving)
        {
            if (fractionForPos < 1)
            {
                fractionForPos += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, desPos, fractionForPos);
            }
            else
            {
                transform.position = desPos;
                isMoving = false;
                fractionForPos = 0;
                animator.SetBool("isJumping", isMoving);
            }
    }*/
    }

    private void Turn()
    {
        if (fractionForRot < 1)
        {
            fractionForRot += Time.deltaTime * rotSpeed;
            transform.rotation = Quaternion.Lerp(startRot, desRot, fractionForRot);
        }
        else
        {
            transform.rotation = desRot;
            isTurning = false;
            fractionForRot = 0;
        }
    }

    private void FindNewRotation(Vector3 dirToTurn)
    {
        startRot = transform.rotation;
        if (transform.forward != dirToTurn)
        {
            desRot = Quaternion.LookRotation(dirToTurn);
            isTurning = true;
        }
    }

    private void CheckShouldIncreaseScore(float currentX)
    {
        if (currentX > PointSystem.Instance.GetScore())
        {
            PointSystem.Instance.AddScore();
        }
    }

    private void AnimationComplete()
    {
        isMoving = false;
        animator.SetBool("isJumping", isMoving);
        Vector3 pos = transform.position;
        pos.y = 0;
        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);
        transform.position = pos;
    }
}
