using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCCollection
{
    None,
    Elf,
    Dwarf,
    Wizzrd,
    Pumpkin
}

public class NPCManager : MonoBehaviour
{
    NPCElf npcElf;

    private void Awake()
    {
        npcElf = GetComponentInChildren<NPCElf>(true);
        npcElf.Init(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public NPCCollection ChangeOnNPC()
    {
        if (npcElf.SetActiveNPC() == NPCCollection.Elf)
        {
            return NPCCollection.Elf;
        }
        else
        {
            return NPCCollection.None;
        }
    }
}
