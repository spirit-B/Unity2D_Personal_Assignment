using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCElf : NPCBase
{
    public override void Init(NPCManager npcManager)
    {
        base.Init(npcManager);
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);

        if ((Input.GetKeyDown(KeyCode.F) || GameManager.isRestart == false) && collision.CompareTag("Player"))
        {
            SceneHandler sceneHandler = FindObjectOfType<SceneHandler>();
            if (sceneHandler != null)
            {
                sceneHandler.OnSceneChange();
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }

    protected override NPCCollection GetNPC()
    {
        return NPCCollection.Elf;
    }
}
