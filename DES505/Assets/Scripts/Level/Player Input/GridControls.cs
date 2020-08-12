using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine;


public class GridControls : MonoBehaviour
{
    public Vector3 currentMousePos;
    private Camera myCamera;

    public Button towerButton;
    public GameObject towerMenuUI;
    public Tilemap mainMap;
    public TileBase towerTile;

    public GameObject treeGameObject;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GetComponent<Camera>();
        currentMousePos = Vector3.zero;
        towerButton.onClick.AddListener(ButtonPressed);
    }

    [System.Obsolete]
    void Update()
    {
        //When using UI the currentm mouse position should stay to the grid selected
        if(!towerMenuUI.active)
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        HighlightGrid();
        HandleUI();
    }

    [System.Obsolete]
    void HandleUI()
    {
        if (Input.GetMouseButtonDown(1) && towerMenuUI.active)
        {
            towerMenuUI.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(1) && !towerMenuUI.active)
        {
            towerMenuUI.SetActive(true);
            towerMenuUI.transform.position = new Vector3(currentMousePos.x, currentMousePos.y, 0);
        }
    }

    public void ButtonPressed()
    {
        if (mainMap.GetTile(mainMap.WorldToCell(currentMousePos)).name == "freeSpace")
        {
            mainMap.SetTile(mainMap.WorldToCell(currentMousePos), towerTile);
            Vector3 newPos = new Vector3(currentMousePos.x, currentMousePos.y, 0);
            Instantiate(treeGameObject, newPos, Quaternion.identity);
        }

        towerMenuUI.SetActive(false);
    }

    [System.Obsolete]
    void HighlightGrid()
    {
        if (mainMap.GetTile(mainMap.WorldToCell(currentMousePos)) && !towerMenuUI.active)
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
