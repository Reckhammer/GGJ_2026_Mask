using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    public int entryLayerID = -1;
    public int exitLayerID = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (LayerManager.Instance.CurrentLayerID != entryLayerID)
                LayerManager.Instance.SetCurrentLayer(entryLayerID);
            else if (LayerManager.Instance.CurrentLayerID != exitLayerID)
                LayerManager.Instance.SetCurrentLayer(exitLayerID);

        }
    }
}
