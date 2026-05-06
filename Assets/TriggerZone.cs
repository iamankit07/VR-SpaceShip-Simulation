using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;        //For adding the unity event
    private void OnTriggerEnter(Collider other)     //When a collider makes contact with the another collider
    {
        if(other.gameObject.tag == targetTag)
        {
            OnEnterEvent.Invoke(other.gameObject);    //it means we can trigger the another event

        }
    }
}
