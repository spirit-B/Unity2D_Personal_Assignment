using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerHandler : MonoBehaviour
{
    ShadeController shadeController;

    private void Start()
    {
        shadeController = GetComponentInParent<ShadeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shadeController.OnPlayerEnterRoom(gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shadeController.OnPlayerExitRoom(gameObject.name);
        }
    }
}
