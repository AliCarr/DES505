using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ClickDragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Tilemap mainMap;          // Get the instance of the tile map
    public GameObject towerMenuUI;       // get the towerMenuUI    
    //public TileBase treeTowerTile;       // This is only the tree tower tile
    public TileBase towerTile;      

    public Sprite tileSprite;         // Initially building tree only

    public Sprite highlightSprite;  // Highlighted image in the Building's deck
    public Sprite defaultSprite;     // The default images of the buildings
    public Sprite miniSprite;    // The mini image of the building

    public Image focusImage;  // Focus image in the Buildings deck main area at the bottom

    public Text description;     // Desciption box text in the buildings deck
    public Text buildingName;  // Building name to be updated on the deck upon clicking a particular building

    public Canvas canvas;   // Get the instance of Canvas in the hierarchy

    private GameObject newBuilding;   // Building to be built
    public GameObject cantBuildtext; // Instance of the "Cant build" Text if SPs are lower than Cost of Building
    public static bool otherBuildingSelected = true;

    public GridControls gridCon;

    private bool isPressing;  // Detect whether image of building has been clicked or not

    // Update is called once per frame
    void Update()
    {
        FocusOnDeck();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        otherBuildingSelected = true;
        isPressing = true;  // Set the boolean isPressing to true when LMB is clicked
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        otherBuildingSelected = false;
        isPressing = false;   // Set the boolean isPressing to false when LMB is re-leased
    }

    public void FocusOnDeck()
    {
        if (isPressing)
        {
            focusImage.sprite = miniSprite;                                    // Update the focused Image of the Building in the deck accordingly
            buildingName.text = GetComponent<Building>().buildingName;         // Update the name of the building in the deck accordingly
            description.text = GetComponent<Building>().descriptionOfBuilding; // Update the description of the building in the deck accordingly
            gameObject.GetComponent<Image>().sprite = highlightSprite;         // Highlight the image in the decks
        }
        else
        {
            if (otherBuildingSelected)
            {
                GetComponent<Image>().sprite = defaultSprite;
            }

        }

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        float costOfBuild = GetComponent<Building>().costOfBuilding; // Find the variable Cost of Building of current building
        float currentSP = FindObjectOfType<SPScripts>().currentSciencePoints; // Find the Current Science Points

        if (costOfBuild <= currentSP)
        {
            newBuilding = Instantiate(gameObject, transform.position, Quaternion.identity);
            Destroy(newBuilding.GetComponentInChildren<Text>());
            newBuilding.GetComponent<Image>().overrideSprite = tileSprite;
            newBuilding.transform.SetParent(canvas.transform);                    // Canvas has to set as the parent of the Image in order to make it visible in the scene
            newBuilding.transform.localScale = new Vector3(1, 1, 1);              // Reset the local scale of the new building image to make it the correct size
        }
        else
        {
            cantBuildtext.SetActive(true);  // Activate the Can't build text if SPs are lesser than Cost of Building
        }
             
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (newBuilding != null)
        {
            newBuilding.transform.position = new Vector3(gridCon.currentMousePos.x, gridCon.currentMousePos.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cantBuildtext.SetActive(false);   // Have to deactivate the Cant build text as soon as the drag ends

        if (newBuilding != null)
        {

            float costOfBuild = GetComponent<Building>().costOfBuilding; // Find the variable Cost of Building of current building

            newBuilding.GetComponent<Image>().color = new Color(255, 255, 255, 0f);

            if (mainMap.GetTile(mainMap.WorldToCell(gridCon.currentMousePos)).name.StartsWith("freeSpace"))
            {
                mainMap.SetTile(mainMap.WorldToCell(gridCon.currentMousePos), towerTile);  // Change the image of the Tile where the Building is built
               // newBuilding.transform.position = mainMap.WorldToCell(gridCon.currentMousePos);
                newBuilding.transform.position = mainMap.WorldToCell(gridCon.currentMousePos);
                newBuilding.GetComponent<ClickDragAndDrop>().enabled = false;  // Disable the Click and Drag script so that the Built building is'nt movable anymore
                newBuilding.GetComponent<BuildingsFunctions>().enabled = true; // Enable the Buildings Functions so that the Building start performing what they can do
                FindObjectOfType<SPScripts>().DecreaseSciencePoints(costOfBuild); // Deduct the Science Points from my account

            }
            else
            {
                Destroy(newBuilding);
            }
            towerMenuUI.SetActive(false);
            // gridCon.ButtonPressed();

        }

        newBuilding = null;  // Setting the newBuilding to null just to make sure the same building doesnt get dragged upon next build
       
    }
}
