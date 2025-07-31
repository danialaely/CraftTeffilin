using UnityEngine;

public class Slot : MonoBehaviour
{
    public string acceptedCassetteTag; // Set this in Inspector for each slot (e.g., "Cassette1", "Cassette2")
    private MeshRenderer meshRenderer;
    private bool cassetteInside = false;
    private GameObject overlappingCassette = null;
    public Head head;

    // Static flag for any slot overlap
    public static bool anyCassetteOverSlot = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!head.isDragging) return;  // if not dragging then dont execute this

            cassetteInside = true;                        //While Dragging:  To see if the Cassette is inside
            overlappingCassette = other.gameObject;       // Store the object in overlapping cassette

            if (meshRenderer != null)
                meshRenderer.enabled = true;
        if (other.CompareTag(acceptedCassetteTag)) // Optional: use more general tag
        {
            anyCassetteOverSlot = true;
        }
        else 
        {
            //Destroy(other.gameObject);
            Debug.Log("Ghalat wala drop hogeya");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == overlappingCassette)
        {
            cassetteInside = false; 
            //anyCassetteOverSlot = false;
            overlappingCassette = null;

            if (meshRenderer != null)
                meshRenderer.enabled = false;
        }
    }

    private void Update()
    {
        // Check for drop while cassette is inside
        if (!head.isDragging && cassetteInside && overlappingCassette != null)  //agar drop kiya hai , cassette is inside , overlappingCassette is true
        {
            // Check correctness
            if (overlappingCassette.CompareTag(acceptedCassetteTag))
            {
                Debug.Log("✅ Correct cassette dropped in slot: " + gameObject.name);
                if (this.gameObject.name == "Slot") 
                {
                    overlappingCassette.transform.position = new Vector3(-1.0f, 2.887f, 8.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingCassette.transform.SetParent(thirdChild);
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    head.CassetteButtons[0].interactable = false;
                }
                if (this.gameObject.name == "Slot2")
                {
                    Debug.Log("Destroy kiun horaha hai Slot 2 per");
                    overlappingCassette.transform.position = new Vector3(-1.5f, 2.887f, 8.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingCassette.transform.SetParent(thirdChild);
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    head.CassetteButtons[1].interactable = false;
                }
                if (this.gameObject.name == "Slot3")
                {
                    overlappingCassette.transform.position = new Vector3(-2.0f, 2.887f, 8.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingCassette.transform.SetParent(thirdChild);
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    head.CassetteButtons[2].interactable = false;
                }
                if (this.gameObject.name == "Slot4")
                {
                    overlappingCassette.transform.position = new Vector3(-2.5f, 2.887f, 8.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingCassette.transform.SetParent(thirdChild);
                    this.gameObject.GetComponent<Collider>().enabled = false;
                    head.CassetteButtons[3].interactable = false;
                }
            }
            else
            {
                Debug.Log("❌ Wrong cassette dropped in slot: " + gameObject.name);
                Destroy(overlappingCassette);
            }

            if (meshRenderer != null)
                meshRenderer.enabled = false;

            cassetteInside = false;
            overlappingCassette = null;
        }
    }
}
