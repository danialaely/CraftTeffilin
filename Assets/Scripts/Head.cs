using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem; // TOP OF FILE
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Head : MonoBehaviour
{
    public Transform targetToRotate;
    public GameObject playBtn;
    public GameObject inventoryPanel;
    public GameObject HeadinventoryPanel;
    public GameObject HandinventoryPanel;
    public Button paperBtn;
    public Button usbBtn;
    public Button boxBtn;
    public Button restartBtn;
    public Button continueBtn;
    public Button contiBtn;

    public GameObject ayatPanel;
    public GameObject ayatPanel2;
    public GameObject cassettePanel;
    public GameObject clickHand;
    public GameObject BoxHand;

    public GameObject usbPrefab;
    public GameObject paperPrefab;
    public GameObject boxPrefab;
    public GameObject handParchiPrefab;
    private GameObject currentDragged;

    public Canvas canvas; // Your UI canvas

    public bool isDragging = false;

    float usbPos = -1.32f;
    public float paperPos;

    [SerializeField] private Button[] ayatButtons;
    public Button[] CassetteButtons;

    bool hello = false;
    bool boxDropped = false;
    private bool usbTriggered = false;
    public bool paperTriggered = false;
    private bool boxTriggered = false;

    public GameObject character;

    public GameObject[] CassettePrefabs;
    public GameObject[] parchiPrefabs;
    private int currentIndex = 0;
    private int currentInd = 0;
    public int i = 0; // Shared counter

    public float rotationSpeed = 5f;
    //private bool isDragging = false;
    private Vector3 lastMousePosition;
    Transform ThirdChild;

    public Image targetImage;           // Assign this in the Inspector
    public Sprite sprite1;             // Assign your 4 sprites in Inspector
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public GameObject rotateTxt;

    Quaternion originalrot;
    public GameObject InventoryCassetteObj1;
    public GameObject InventoryCassetteObj2;
    public GameObject InventoryCassetteObj3;
    public GameObject InventoryCassetteObj4;

    private void Start()
    {
        // Optional: Auto-assign the 3rd child if not assigned in inspector
        if (targetToRotate == null && transform.childCount > 3)
        {
            targetToRotate = transform.GetChild(3);
        }

        inventoryPanel.SetActive(false);
        HeadinventoryPanel.SetActive(false);
        //paperBtn.enabled = false;
        paperPos = -0.566f;
        clickHand.SetActive(false);
        BoxHand.SetActive(false);
        ThirdChild = this.transform.GetChild(3);
        //paperBtn.interactable = false;
        originalrot = this.transform.rotation;
    }

    void Update()
    {
        if (isDragging && currentDragged != null)
        {
            Vector2 pos = Pointer.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10f)); // y 900f
            Debug.Log("PosY:"+pos.y);
            currentDragged.transform.position = worldPos;
        }

        if (Keyboard.current.dKey.isPressed) //&& ThirdChild.childCount >= 6
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

            //if current index =0 then rotate cassette 1
            if (currentIndex == 0) 
            {
                InventoryCassetteObj1.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 1) 
            {
                InventoryCassetteObj2.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 2) 
            {
                InventoryCassetteObj3.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 3) 
            {
                InventoryCassetteObj4.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
        }
        else if (Keyboard.current.aKey.isPressed) //&& ThirdChild.childCount >= 6
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);

            //if current index =0 then rotate cassette 1
            if (currentIndex == 0)
            {
                InventoryCassetteObj1.transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 1)
            {
                InventoryCassetteObj2.transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 2)
            {
                InventoryCassetteObj3.transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
            else if (currentIndex == 3)
            {
                InventoryCassetteObj4.transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
        }
        else
        {
            if (transform.rotation != originalrot) 
            {
                this.transform.rotation = originalrot;
            }
        }
    }

    public void PlayBtn()
    {
        if (targetToRotate != null)
        {
            StartCoroutine(RotateSmoothly(targetToRotate, -90f));
            playBtn.SetActive(false);
            inventoryPanel.SetActive(true);
        }
    }

    public void Continue() 
    {
        ScaleDown(this.gameObject);
        this.transform.position = new Vector3(-3.05f, 1.95f, 12.65f);
        StartCoroutine(spawncharacter1(0.4f));
        continueBtn.gameObject.SetActive(false);
        rotateTxt.SetActive(false);
    }
    public void ContiBtn() 
    {
        ScaleDown(this.gameObject);
        this.transform.position = new Vector3(-3.05f, 1.95f, 12.65f);
        StartCoroutine(spawncharacter(0.4f));
        contiBtn.gameObject.SetActive(false);
        rotateTxt.SetActive(false);
    }

    public IEnumerator RotateSmoothly(Transform target, float angle)
    {
        Quaternion startRotation = target.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(angle, 0, 0);

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            target.rotation = Quaternion.Slerp(startRotation, endRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.rotation = endRotation; // Ensure final rotation is exact
    }

    public void HeadBtn() 
    {
        inventoryPanel.SetActive(false);
        //HeadinventoryPanel.SetActive(true);
        cassettePanel.SetActive(true);
        //Open CassettePanel "Consist of Cassettes and Ayats"
        //BoxHand.SetActive(true);
    }

    public void HandButton() 
    {
        inventoryPanel.SetActive(false);
        HandinventoryPanel.SetActive(true);
        //BoxHand.SetActive(true);
    }

    public void BeginDragUsb()
    {
        if (CassettePrefabs == null || currentIndex < 0 || currentIndex >= CassettePrefabs.Length) return;

        currentDragged = Instantiate(CassettePrefabs[currentIndex], transform.position, Quaternion.Euler(-180f, 0f, 0f));
        isDragging = true;
        Slot.anyCassetteOverSlot = false;
        Debug.Log("Dragging: " + CassettePrefabs[currentIndex].name);
        //CassetteButtons[0].interactable = false;

        BoxHand.SetActive(false);
    }

    /* public void BeginDragCassette1() 
    {
        SelectCassette(0);
        if (CassettePrefabs == null || currentIndex < 0 || currentIndex >= CassettePrefabs.Length) return;

        currentDragged = Instantiate(CassettePrefabs[currentIndex], transform.position, Quaternion.Euler(-180f, 0f, 0f));
        isDragging = true;
        Slot.anyCassetteOverSlot = false;
        Debug.Log("Dragging: " + CassettePrefabs[currentIndex].name);
        //CassetteButtons[0].interactable = false;

        BoxHand.SetActive(false);
    } */

    public void BeginDragPaper()
    {
        if (parchiPrefabs == null) return;

        if (hello)
        {
            currentDragged = Instantiate(parchiPrefabs[currentInd], transform.position, Quaternion.Euler(-180f, 0f, 0f));
            isDragging = true;
            Slot.anyCassetteOverSlot = false;
            Debug.Log("Dragging: " + parchiPrefabs[currentInd].name);
        }
        else 
        {
            Debug.Log("Select Paper");
            clickHand.SetActive(true);
        }
    }

    public void BeginDragBox()
    {
        if (boxPrefab == null || boxDropped) return;
        currentDragged = Instantiate(boxPrefab);
        isDragging = true;
        boxTriggered = false;
        BoxHand.SetActive(false);
    }

    public void BeginDragHandParchi()
    {
        if (handParchiPrefab == null) return;
        currentDragged = Instantiate(handParchiPrefab);
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;

            Debug.Log("Collider:"+Slot.anyCassetteOverSlot);
            Debug.Log("Current Drag:"+currentDragged);

        if (!Slot.anyCassetteOverSlot && currentDragged != null)
        {
            Debug.Log("Cassette dropped outside — destroying.");
            Destroy(currentDragged);
        }

        currentDragged = null;
    }

    public void SetBool(bool paperT) 
    {
        paperTriggered = paperT;
    }

    public bool GetPaperTriggered() { return paperTriggered; }

    public void EndPaperDrag() 
    {
        isDragging = false;

        if (!Cassette.anyParchiOverSlot && currentDragged != null)
        {
            Debug.Log("Cassette dropped outside — destroying.");
            Destroy(currentDragged);
        }

        currentDragged = null;
    }

    public void EndBoxDrag() 
    {
        isDragging = false;

        if (!boxTriggered && currentDragged != null)
        {
            Destroy(currentDragged); // auto cleanup
            Debug.Log("Box was not placed correctly — destroyed");
        }

        currentDragged = null;
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.CompareTag("Stick")) 
        {
            Debug.Log("Takra gaya");
            usbTriggered = true;
            EndDrag();
            other.transform.position = new Vector3(usbPos, 2.887f, 8.157f);
            Transform thirdChild = transform.GetChild(3);
            other.transform.SetParent(thirdChild);

            usbPos -= 0.51f;

            if (usbPos <= -2.95f) 
            {
                usbBtn.interactable = false;
                paperBtn.interactable = true;
            }
            //-2.85
        }*/

      /*  if (other.CompareTag("Paper")) 
        {
            Debug.Log("Paper Takraya");
            paperTriggered = true;
            //EndDrag();
            EndPaperDrag();
            other.transform.position = new Vector3(paperPos, 2.862f, 9.03f);

            Transform thirdChild = transform.GetChild(3);
            other.transform.SetParent(thirdChild);

            hello = false;
            int i = 0;
            foreach (Button b in ayatButtons) 
            {
                if (!b.interactable) 
                {
                    i++;
                }

                if (i>=4) 
                {
                    Debug.Log("I:"+i);
                    if (targetToRotate != null)
                    {
                        StartCoroutine(RotateSmoothly(targetToRotate, 90f));
                        ScaleDown(this.gameObject);
                        this.transform.position = new Vector3(-3.05f, 1.95f, 12.65f);
                        StartCoroutine(spawncharacter1(0.4f));
                       // this.transform.localRotation = Quaternion.Euler(8.5f, 0f, 6.21f);
                       //GameObject man = Instantiate(character, new Vector3(0.6f, -12.12f, 8.99f), Quaternion.Euler(0, -99.3f, -4.46f));
                        //man.transform.localScale = new Vector3(12.0f, 12.0f, 12.0f);
                     //   playBtn.SetActive(false);
                      //  inventoryPanel.SetActive(true);
                    }
                }
            }

            //usbPos -= 0.51f;
            // Disable corresponding button
        }*/

        if (other.CompareTag("Box"))
        {
            Debug.Log("Box Takraya");
            boxTriggered = true;
            //EndDrag();
            EndBoxDrag();
            other.transform.position = new Vector3(-1.0f, 2.811186f, 8.01f);

            Transform thirdChild = transform.GetChild(3);
            other.transform.SetParent(thirdChild);

            boxDropped = true;
            boxBtn.interactable = false;
            //usbPos -= 0.51f;
        }

        if (other.CompareTag("HandPaper")) 
        {
            EndDrag();
            other.transform.position = new Vector3(-1.811f, 2.629f, 9.127f);

            Transform thirdChild = transform.GetChild(3);
            other.transform.SetParent(thirdChild);

            StartCoroutine(RotateSmoothly(targetToRotate, 90f));
            //ScaleDown(this.gameObject);
            //this.transform.position = new Vector3(-3.05f, 1.95f, 12.65f);
            contiBtn.gameObject.SetActive(true);
            rotateTxt.SetActive(true);
            //StartCoroutine(spawncharacter(0.4f));
        }
    }

    IEnumerator spawncharacter(float del) 
    {
        yield return new WaitForSeconds(del);
        GameObject man = Instantiate(character, new Vector3(0.6f, -12.12f, 8.99f), Quaternion.Euler(0, -99.3f, -4.46f));
        man.transform.localScale = new Vector3(12.0f, 12.0f, 12.0f);

        yield return new WaitForSeconds(0.5f);
        restartBtn.gameObject.SetActive(true);
        HeadinventoryPanel.SetActive(false);
        HandinventoryPanel.SetActive(false);
    }

    IEnumerator spawncharacter1(float del) 
    {
        yield return new WaitForSeconds(del);
        GameObject man = Instantiate(character, new Vector3(-2.31f, -18.3f, 9.93f), Quaternion.Euler(0, -55f, -3.74f));
        man.transform.localScale = new Vector3(12.0f, 12.0f, 12.0f);

        Transform hathwala = man.transform.GetChild(12);
        hathwala.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        HeadinventoryPanel.SetActive(false);
        HandinventoryPanel.SetActive(false);
        restartBtn.gameObject.SetActive(true);
    }

    public void ScaleDown(GameObject target)
    {
        StartCoroutine(ScaleOverTime(target, new Vector3(0.01f, 0.01f, 0.01f), 0.5f)); // 0.5 sec duration
    }

    private IEnumerator ScaleOverTime(GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale; // Snap final scale
        StartCoroutine(moveanywheremunWala(0.3f));
    }

    IEnumerator moveanywheremunWala(float del) 
    {
        yield return new WaitForSeconds(del); //
        transform.position = new Vector3(1000f,1000f,1000f);
    }

    public void OnPaperClick() 
    {
        ayatPanel.SetActive(true);
        clickHand.SetActive(false);
    }

    public void onBaraPaperClick() 
    {
        ayatPanel2.SetActive(true);
    }

    public void CrossButton2() 
    {
        ayatPanel2.SetActive(false);
    }

    public void CrossAyatPanel() 
    {
        ayatPanel.SetActive(false);
    }

    public void AyatOne() 
    {
        ayatPanel.SetActive(false);
        paperPos = -0.566f;
        hello = true;
        SelectParchi(0);
       // ayatButtons[0].interactable = false;
    }
    public void AyatTwo() 
    {
        ayatPanel.SetActive(false);
        paperPos = -1.076f;
        hello = true;
        SelectParchi(1);
       // ayatButtons[1].interactable = false;
    }
    public void AyatThree() 
    {
        ayatPanel.SetActive(false);
        paperPos = -1.586f;
        hello = true;
        SelectParchi(2);
        //ayatButtons[2].interactable = false;
    }
    public void AyatFour() 
    {
        ayatPanel.SetActive(false);
        paperPos = -2.096f;
        hello = true;
        SelectParchi(3);
        //ayatButtons[3].interactable = false;
    }

    public void LeftCassette() 
    {
        //Set LeftCassette Prefab
        SelectCassette(0);
        //CassetteButtons[0].interactable = false;
        //cassettePanel.SetActive(false);
        targetImage.sprite = sprite1;
    }

    public void SecondCassette()
    {
        //Set LeftCassette Prefab
        SelectCassette(1);
        //CassetteButtons[1].interactable = false;
        //cassettePanel.SetActive(false);
        targetImage.sprite = sprite2;
    }

    public void ThirdCassette()
    {
        //Set LeftCassette Prefab
        SelectCassette(2);
        //cassettePanel.SetActive(false);
        //CassetteButtons[2].interactable = false;
        targetImage.sprite = sprite3;
    }

    public void RightCassette()
    {
        //Set LeftCassette Prefab
        SelectCassette(3);
        //cassettePanel.SetActive(false);
        //CassetteButtons[3].interactable = false;
        targetImage.sprite = sprite4;
    }

    public void OnCassetteClick() 
    {
        cassettePanel.SetActive(true);
    }

    public void Restart() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectCassette(int index)
    {
        currentIndex = index;
    }

    public void SelectParchi(int index) 
    {
        currentInd = index;
    }

    public void CrossCassettePanel() 
    {
        cassettePanel.SetActive(false);
    }

}
