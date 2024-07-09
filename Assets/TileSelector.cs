using UnityEngine;
using TMPro;

public class TileSelector : MonoBehaviour
{
    public TextMeshProUGUI tileInfoText;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            if (tile != null)
            {
                tileInfoText.text = $"Tile: ({tile.x}, {tile.y})";
            }
        }
    }
}
