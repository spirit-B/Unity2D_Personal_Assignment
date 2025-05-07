using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShadeController : MonoBehaviour
{
    [SerializeField] private Transform roomShadersParent;

    private List<GameObject> roomShaders = new List<GameObject>();
    private GameObject wholeMapShader;

    private void Awake()
    {
        int count = roomShadersParent.childCount;

        for (int i = 0; i < count; i++)
        {
            if (roomShadersParent.GetChild(i).gameObject.name == "WholeMap_Shade")
            {
                wholeMapShader = roomShadersParent.GetChild(i).gameObject;
            }
            else
            {
                roomShaders.Add(roomShadersParent.GetChild(i).gameObject);
            }
        }
    }

    public void OnPlayerEnterRoom(string triggerName)
    {
        string roomName = triggerName.Replace("_Trigger", "_Shade");
        wholeMapShader.SetActive(true);

        foreach (GameObject shader in roomShaders)
        {
            if (shader.name == roomName)
                shader.SetActive(true);
        }
    }

    public void OnPlayerExitRoom(string triggerName)
    {
        string roomName = triggerName.Replace("_Trigger", "_Shade");
        wholeMapShader.SetActive(false);

        foreach (GameObject shader in roomShaders)
        {
            if (shader.name == roomName)
                shader.SetActive(false);
        }
    }
}
