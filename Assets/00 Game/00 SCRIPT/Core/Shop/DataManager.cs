using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using HuynnLib;

public class DataManager : Singleton<DataManager>
{
    [Header("--- Items ---")]
    [SerializeField] List<ItemDataSO> _genaralDataItems = new();
    public List<ItemDataSO> genaralDataItems;

    private void Start()
    {
        _genaralDataItems = Resources.LoadAll<ItemDataSO>("Items").ToList();
    }

    private void OnDrawGizmosSelected()
    {
        _genaralDataItems = Resources.LoadAll<ItemDataSO>("Items").ToList();
    }
}
