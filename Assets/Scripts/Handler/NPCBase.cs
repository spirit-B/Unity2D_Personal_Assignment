using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCBase : MonoBehaviour
{
    protected NPCManager npcManager;

    public virtual void Init(NPCManager npcManager)
    {
        this.npcManager = npcManager;
    }


    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�÷����̰� �������� ������.");
            SceneHandler.isInRange = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneHandler.isInRange = false;
        }
    }

    protected abstract NPCCollection GetNPC();

    public NPCCollection SetActiveNPC()
    {
        return GetNPC();
    }
}
