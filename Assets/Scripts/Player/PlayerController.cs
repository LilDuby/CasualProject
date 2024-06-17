using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Moverment")]
    [Range(0f, 1f)] public float moveSpeed;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;
    public bool onMove = false;

    private Animator animator;

    [SerializeField] private AudioClip moveClip;
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInChildren<Animator>();
    }

    void Move()
    {
        onMove = true;
        StartCoroutine("Movement");
    }

    IEnumerator Movement()
    {
        yield return null;
        float move = 0.05f;
        Vector3 curPos = transform.position;
        Vector3 movePos = new Vector3(transform.position.x + curMovementInput.x, transform.position.y, transform.position.z + curMovementInput.y);
        animator.SetTrigger("Move");
        if (moveClip) SoundManager.PlayClip(moveClip);
        switch (curMovementInput.x)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;

            case -1:
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                break;
        }
        switch (curMovementInput.y)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;

                case -1:
                transform.rotation = Quaternion.Euler(0f,180f,0f);
                break;
        }
        while (onMove)
        {
            transform.position = Vector3.Lerp(new Vector3(curPos.x, curPos.y, curPos.z), new Vector3(movePos.x, movePos.y, movePos.z), move);
            if (move <= 1f)
            {
                move += 0.05f;
            }
            else
            {
                onMove = false;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !onMove)
        {
            curMovementInput = context.ReadValue<Vector2>();
            Move();
        }
    }
}
