using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ClickDragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{            
    public TileBase towerTile;      

    public Sprite tileSprite;         

    public Sprite highlightSprite;  
    public Sprite defaultSprite;    
    public Sprite miniSprite;    

    public Image focusImage;  

    public Text description;     
    public Text buildingName;  

    public Canvas canvas;   

    private GameObject newBuilding;  
    public GameObject cantBuildtext; 
    public static bool otherBuildingSelected = true;

    //[SerializeField] private GridControls gridCon;

    private bool isPressing;  

    private void Awake()
    {
        //gridCon = GridControls.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        FocusOnDeck();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        otherBuildingSelected = true;
        isPressing = true;  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        otherBuildingSelected = false;
        isPressing = false;  
    }

    public void FocusOnDeck()
    {
        if (isPressing)
        {
            focusImage.sprite = miniSprite;                                   
            buildingName.text = GetComponent<Building>().buildingName;        
            description.text = GetComponent<Building>().descriptionOfBuilding; 
            gameObject.GetComponent<Image>().sprite = highlightSprite;        
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
        float costOfBuild = GetComponent<Building>().costOfBuilding; 
        float currentSP = FindObjectOfType<SPScripts>().GetSciencePoints(); 

        if (costOfBuild <= currentSP)
        {
            newBuilding = Instantiate(gameObject, transform.position, Quaternion.identity);
            Destroy(newBuilding.GetComponentInChildren<Text>());
            newBuilding.GetComponent<Image>().overrideSprite = tileSprite;
            newBuilding.transform.SetParent(canvas.transform);                    
            newBuilding.transform.localScale = new Vector3(1, 1, 1);             
        }
        else
        {
            cantBuildtext.SetActive(true);  
        }
             
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (newBuilding != null)
        {
            newBuilding.transform.position = new Vector3(GridControls.Instance.currentMousePos.x,GridControls.Instance.currentMousePos.y, 0);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cantBuildtext.SetActive(false);   

        if (newBuilding != null)
        {
            Tilemap mainMap = GridControls.Instance.mainMap;
            float costOfBuild = GetComponent<Building>().costOfBuilding; 

            newBuilding.GetComponent<Image>().color = new Color(255, 255, 255, 0f);

            if (mainMap.GetTile(mainMap.WorldToCell(GridControls.Instance.currentMousePos)).name.StartsWith("freeSpace"))
            {
                mainMap.SetTile(mainMap.WorldToCell(GridControls.Instance.currentMousePos), towerTile);
                newBuilding.transform.position = mainMap.GetCellCenterWorld(mainMap.WorldToCell(GridControls.Instance.currentMousePos));
                newBuilding.GetComponent<ClickDragAndDrop>().enabled = false;  
                newBuilding.GetComponent<BuildingsFunctions>().enabled = true; 
                FindObjectOfType<SPScripts>().DecreaseSciencePoints(costOfBuild); 

            }
            else
            {
                Destroy(newBuilding);
            }
            //gridCon.ButtonPressed();
        }

        newBuilding = null;  
       
    }
}
