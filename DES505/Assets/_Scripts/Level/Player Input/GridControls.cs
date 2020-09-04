using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine;


public class GridControls : Singleton<GridControls>
{
    public Vector3 currentMousePos;

    public Tilemap mainMap;

    public void Init()
    {
        currentMousePos = Vector3.zero;
    }

    [System.Obsolete]
    void Update()
    {
         currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

         HighlightGrid();
    }

    [System.Obsolete]
    void HighlightGrid()
    {
        if (mainMap.GetTile(mainMap.WorldToCell(currentMousePos)))
        {
            mainMap.RefreshAllTiles();
            mainMap.SetTileFlags(mainMap.WorldToCell(currentMousePos), TileFlags.None);

            HighlightCheck("freeSpace" , Color.green);
            HighlightCheck("takenSpace", Color.red);
            HighlightCheck("Path"      , Color.red);
            HighlightCheck("Tower"     , Color.yellow);
        }
    }

    void HighlightCheck(string name, Color color)
    {
        if (mainMap.GetTile(mainMap.WorldToCell(currentMousePos)).name.StartsWith(name))
            mainMap.SetColor(mainMap.WorldToCell(currentMousePos), color);
    }
}


/*  
 *  Functionality Required:
 *      - Bring up UI identifier when hovered over enemy or tower
 */
