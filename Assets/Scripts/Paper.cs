using UnityEngine;

public class Paper : MonoBehaviour
{
    public Head head;

    void Start()
    {
        head = FindFirstObjectByType<Head>();
        this.transform.rotation = Quaternion.Euler(0, 0, 90f);
        StartCoroutine(CheckAndDestroyRoutine());
    }

    private System.Collections.IEnumerator CheckAndDestroyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // wait for 10 seconds

            if (!head.isDragging && transform.parent == null)
            {
                Debug.Log("🗑 Paper destroyed due to inactivity.");
                Destroy(gameObject);
                yield break; // stop the coroutine after destroying
            }
        }
    }
}
