using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject openModal;

    public void ShowModal()
    {
        openModal.SetActive(true);  
    }
}
