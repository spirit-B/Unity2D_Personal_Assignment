using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandler : MonoBehaviour
{
    private bool isLeft = false;
    private bool isInRange = false;
    private SpriteRenderer leverSprite;

    DoorController doorController;

    private void Start()
    {
        leverSprite = GetComponent<SpriteRenderer>();
        doorController = GameObject.FindObjectOfType<DoorController>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown("f"))
        {
            isLeft = !isLeft;
            leverSprite.flipX = isLeft;
            doorController.DoorOpenAndClose(gameObject.name, isLeft);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isInRange && collision.CompareTag("Player"))
            isInRange = false;
    }
}
