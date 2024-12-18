using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject[] invetoryTabs;
    public GameObject capInfo;
    public GameObject statsInfo;

    private GameObject currentTab;

    private void Start()
    {
        if (currentTab == null)
        {
            currentTab = invetoryTabs[0];
            capInfo.SetActive(true);
            statsInfo.SetActive(false);
        }
    }

    public void AlternateInventory()
    {
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
            currentTab.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
            currentTab.SetActive(true);
        }
    }

    public void OpenCapidex()
    {
        CloseAllTabs();
        invetoryTabs[0].SetActive(true);
        currentTab = invetoryTabs[0];

        capInfo.SetActive(true);
        statsInfo.SetActive(false);
    }

    public void OpenCapybaras()
    {
        CloseAllTabs();
        invetoryTabs[1].SetActive(true);
        currentTab = invetoryTabs[1];

        capInfo.SetActive(false);
        statsInfo.SetActive(true);
    }

    public void OpenTeam()
    {
        CloseAllTabs();
        invetoryTabs[2].SetActive(true);
        currentTab = invetoryTabs[2];

        capInfo.SetActive(false);
        statsInfo.SetActive(true);
    }

    public void OpenItems()
    {
        CloseAllTabs();
        invetoryTabs[3].SetActive(true);
        currentTab = invetoryTabs[3];

        capInfo.SetActive(false);
        statsInfo.SetActive(false);
    }

    private void CloseAllTabs()
    {
        for (int i = 0; i < invetoryTabs.Length; i++) invetoryTabs[i].SetActive(false);
    }
    
}

