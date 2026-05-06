using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class MeteroPistol : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public LayerMask layerMask;   //This is for the raycast
    public Transform shootSource;  //This is the starting point of the raycast
    public float distance = 10;   //This is the maximum distance of our raycast

    private bool rayActivate = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable xRGrabInteractable = GetComponent<XRGrabInteractable>();
        xRGrabInteractable.activated.AddListener(x=> StartShoot());   //This is when the interactable is activated  
        //This means when you grab an object and tha you press on the activation button which you automatically set to the trigger button

        xRGrabInteractable.deactivated.AddListener(x=> StopShoot());
    }
    public void StartShoot()  //it doesnt have any particular argument that listener needs to have 
    {
        particleSystem.Play();
        rayActivate = true;
    }
    public void StopShoot()
    {
         particleSystem.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayActivate)
          RayCastCheck();
    }
    void RayCastCheck()
    {
        // RaycastHit hit;

        bool hasHit = Physics.Raycast(shootSource.position,shootSource.forward,out RaycastHit hit , distance , layerMask);
        if (hasHit) {
            hit.transform.gameObject.SendMessage("Break",SendMessageOptions.DontRequireReceiver);   //It means i send the message to the Break function and
            //  if the break function is not exist then it just does nothing silently because of DontRequireReceiver
        }
    }
}
