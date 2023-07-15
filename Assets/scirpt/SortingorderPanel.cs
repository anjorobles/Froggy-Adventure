using UnityEngine;
using UnityEngine.UI;

public class SortingorderPanel : MonoBehaviour
{
    private void Start()
    {
        int sortingOrder = GetComponent<Canvas>().sortingOrder;
        Debug.Log("Sorting Order: " + sortingOrder);
    }
}
