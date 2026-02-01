using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    public int layerID = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            LayerManager.Instance.SetCurrentLayer(layerID);
    }
}
