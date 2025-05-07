using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform doorsParent;

    private List<GameObject> doors = new List<GameObject>();

    private void Awake()
    {
        int count = doorsParent.childCount;

        for (int i = 0; i < count; i++)
        {
            doors.Add(doorsParent.GetChild(i).gameObject);
        }
    }

    public void DoorOpenAndClose(string leverName, bool isOpen)
    {
        string roomName = leverName.Replace("_Lever", "_Door");

        foreach (GameObject door in doors)
        {
            if (door.name == roomName)
            {
                door.SetActive(isOpen);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
