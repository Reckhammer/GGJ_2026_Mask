using System;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public LayerManager Instance {  get; private set; }
    public int CurrentLayerID { get; private set; } = 0;
    public LayerObjectPair[] layers;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetCurrentLayerToActive();
    }

    public void SetCurrentLayer(int layerToSet)
    {
        CurrentLayerID = layerToSet;
        SetCurrentLayerToActive();
    }

    private void SetCurrentLayerToActive()
    {
        foreach (var layer in layers)
            layer.SetLayerObjectActive(layer.layerID == CurrentLayerID);
    }

    [Serializable]
    public struct LayerObjectPair
    {
        public int layerID;
        public GameObject[] layerObjects;

        public void SetLayerObjectActive(bool isActive)
        {
            foreach (var layerObject in layerObjects)
                layerObject.SetActive(isActive);
        }
    }
}
