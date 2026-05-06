using UnityEngine;

public class TrashDispsoe : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(InsideTrash);
    }
    public void InsideTrash(GameObject g)
    {
        g.SetActive(false);
    }
}
//Basically this code is use for disable any gameobject that is inside the trash.