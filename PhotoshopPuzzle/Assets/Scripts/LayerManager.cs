using System;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public static LayerManager Instance {  get; private set; }
    public int CurrentLayerID { get; private set; } = 0;
    public LayerObjectPair[] layers;

    public Action LayerChange;

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
        // Don't do anything if already on the same layer
        if (CurrentLayerID == layerToSet) return;

        Debug.Log($"LayerManager: Setting layer ID to {layerToSet} from {CurrentLayerID}", this);
        CurrentLayerID = layerToSet;
        SetCurrentLayerToActive();
        LayerChange?.Invoke();
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
