using UnityEngine;
using UnityEngine.UI;

public class Cassette : MonoBehaviour
{
    public Head head;
    private bool parchiInside = false;
    private Renderer cassetteRenderer;
    private Color originalColor;
    //private Button continueBtn;
    // int i = 0;

    public string acceptedParchiTag; // Set this in Inspector for each slot (e.g., "Cassette1", "Cassette2")
    //private MeshRenderer meshRenderer;
    //private bool cassetteInside = false;
    private GameObject overlappingParchi = null;
    public static bool anyParchiOverSlot = false;

    private void Start()
    {
        head = FindFirstObjectByType<Head>();

        cassetteRenderer = GetComponent<Renderer>();
        if (cassetteRenderer != null)
        {
            originalColor = cassetteRenderer.material.color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!head.isDragging) return;

        parchiInside = true;
        overlappingParchi = other.gameObject;

        if (other.gameObject.name == "Paper(Clone)" || other.gameObject.name == "Paper2(Clone)" ||
            other.gameObject.name == "Paper3(Clone)" || other.gameObject.name == "Paper4(Clone)") 
        {
            cassetteRenderer.material.color = Color.green;
        }


        if (other.CompareTag(acceptedParchiTag)) // Optional: use more general tag
        {
            anyParchiOverSlot = true;
        }
        else
        {
            //Destroy(other.gameObject);
            Debug.Log("Ghalat wala drop hogeya");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Paper(Clone)" || other.gameObject.name == "Paper2(Clone)" ||
            other.gameObject.name == "Paper3(Clone)" || other.gameObject.name == "Paper4(Clone)")
        {
            parchiInside = false;
            cassetteRenderer.material.color = originalColor;
        }
    }

    private void Update()
    {
        // Check for drop while cassette is inside
        if (!head.isDragging && parchiInside && overlappingParchi != null)
        {
            // Check correctness
            if (overlappingParchi.CompareTag(acceptedParchiTag))
            {
                Debug.Log("✅ Correct parchi dropped in Cassette: " + gameObject.name);
                if (this.gameObject.name == "C1(Clone)")
                {
                    overlappingParchi.transform.position = new Vector3(-1.75f, 2.887f, 9.15f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingParchi.transform.SetParent(thirdChild);
                    //head.i++;
                    Debug.Log("i:" + head.i);
                    Debug.Log("Child count of MunWala:"+ thirdChild.childCount);

                    if (thirdChild.childCount >= 13) 
                    {
                        head.i = 4; 
                        StartCoroutine(head.RotateSmoothly(head.targetToRotate, 90f));
                        head.continueBtn.gameObject.SetActive(true);
                        head.rotateTxt.SetActive(true);
                    }

                    if (head.i >= 4)
                    {
                    }
                }
                if (this.gameObject.name == "C2(Clone)")
                {
                    overlappingParchi.transform.position = new Vector3(-2.3f, 2.887f, 9.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingParchi.transform.SetParent(thirdChild);
                    //head.i++;
                    Debug.Log("i:" + head.i);
                    Debug.Log("Child count of MunWala:" + thirdChild.childCount);

                    if (thirdChild.childCount >= 13)
                    {
                        head.i = 4;
                        StartCoroutine(head.RotateSmoothly(head.targetToRotate, 90f));
                        head.continueBtn.gameObject.SetActive(true);
                        head.rotateTxt.SetActive(true);
                    }

                    if (head.i >= 4)
                    {
                    }
                }
                if (this.gameObject.name == "C3(Clone)")
                {
                    overlappingParchi.transform.position = new Vector3(-2.9f, 2.887f, 9.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingParchi.transform.SetParent(thirdChild);
                    //head.i++;
                    Debug.Log("Child count of MunWala:" + thirdChild.childCount);

                    if (thirdChild.childCount >= 13)
                    {
                        head.i = 4;
                        StartCoroutine(head.RotateSmoothly(head.targetToRotate, 90f));
                        head.continueBtn.gameObject.SetActive(true);
                        head.rotateTxt.SetActive(true);
                    }

                    Debug.Log("i:" + head.i);
                    if (head.i >= 4)
                    {
                    }
                }   
                if (this.gameObject.name == "C4(Clone)")
                {
                    overlappingParchi.transform.position = new Vector3(-3.4f, 2.887f, 9.157f);
                    Transform thirdChild = head.transform.GetChild(3);
                    overlappingParchi.transform.SetParent(thirdChild);
                    //head.i++;
                    Debug.Log("Child count of MunWala:" + thirdChild.childCount);

                    if (thirdChild.childCount >= 13)
                    {
                        head.i = 4;
                        StartCoroutine(head.RotateSmoothly(head.targetToRotate, 90f));
                        head.continueBtn.gameObject.SetActive(true);
                        head.rotateTxt.SetActive(true);
                    }

                    Debug.Log("i:" + head.i);
                    if (head.i >= 4)
                    {
                    }
                }
            }
            else
            {
                Debug.Log("❌ Wrong parchi dropped in Cassette: " + gameObject.name);
                Debug.Log("Destroying:"+overlappingParchi);
                //Destroy(overlappingParchi);
            }

            cassetteRenderer.material.color = originalColor;

            parchiInside = false;
            overlappingParchi = null;
        }
    }
}
