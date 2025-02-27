using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCMoveee : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 targetPosition;
    private bool isTurning = false;

    void Start()
    {
        SetNextTarget();
    }

    void Update()
    {
        if (!isTurning)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            StartCoroutine(TurnAndMove());
        }
    }

    IEnumerator TurnAndMove()
    {
        isTurning = true;
        yield return new WaitForSeconds(0.5f);
        transform.Rotate(0, 180, 0);
        SetNextTarget();
        isTurning = false;
    }

    void SetNextTarget()
    {
        targetPosition = transform.position + transform.forward * moveDistance;
    }
}
