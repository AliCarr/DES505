using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickDragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image highlightImage;  // Highlighting image in the Buildings deck
    public Text description;     // Desciption box text in the buildings deck
    public Text buildingName;  // Building name to be updated on the deck upon clicking a particular building
    public GameObject newBuilding;   // Building to be built
    public Canvas canvas;   // Get the instance of Canvas in the hierarchy
    public GameObject cantBuildtext; // Instance of the "Cant build" Text if SPs are lower than Cost of Building
    public GridControls gridCon;

    private bool isPressing;  // Detect whether image of building has been clicked or not

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;  // Set the boolean isPressing to true when LMB is clicked
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;   // Set the boolean isPressing to false when LMB is re-leased
    }

    public void HighlightOnDeck()
    {
        if (isPressing)
        {
            highlightImage.sprite = this.GetComponent<Image>().sprite;  // Update the Highlighted Image of the Building in the deck accordingly
            buildingName.text = this.GetComponent<Building>().buildingName; // Update the name of the building in the deck accordingly
            description.text = this.GetComponent<Building>().descriptionOfBuilding; // Update the description of the building in the deck accordingly
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        HighlightOnDeck();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        float costOfBuild = this.GetComponent<Building>().costOfBuilding; // Find the variable Cost of Building of current building
        float currentSP = FindObjectOfType<SPScripts>().currentSciencePoints; // Find the Current Science Points

        if (costOfBuild <= currentSP)
        {
            newBuilding = Instantiate(gameObject, transform.position, Quaternion.identity);
            newBuilding.transform.SetParent(canvas.transform);
            FindObjectOfType<SPScripts>().DecreaseSciencePoints(costOfBuild);
            
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
            newBuilding.transform.position = Input.mousePosition; //
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cantBuildtext.SetActive(false);   // Have to deactivate the Cant build text as soon as the drag ends

        if (newBuilding != null)
        {
            //newBuilding.GetComponent<ClickDragAndDrop>().enabled = false;  // Disable the Click and Drag script so that the Built building is'nt movable anymore
            Destroy(newBuilding.GetComponent<ClickDragAndDrop>()); // Remove the Click and Drag script so that the Built building is'nt movable anymore
            newBuilding.GetComponent<BuildingsFunctions>().enabled = true; // Enable the Buildings Functions so that the Building start performing what they can do
            gridCon.ButtonPressed();
            newBuilding.SetActive(false);
        }

        newBuilding = null;  // Setting the newBuilding to null just to make sure the same building doesnt get dragged upon next build
       
    }
}
