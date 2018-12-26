using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class BookBehavior : MonoBehaviour
{


    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

    RaycastHit hit;
    Animator anim;
    Rigidbody rb;
    Interactable interactable;
    bool open = false;
    bool isInHand;

    private void Start()
    {
        anim = GetComponent<Animator>();
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
    }


    public void Grab()
    {
        isInHand = true;
    }
    public void LetGo()
    {
        isInHand = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("pedestal") && !isInHand && !open)
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;
            rb.useGravity = false;
            rb.isKinematic = true;
            anim.Play("Open");
            open = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("pedestal") && open)
        {
            rb.useGravity = true;
           // rb.isKinematic = false;
            anim.Play("Close");
            open = false;
        }
    }


    public void CheckForPedestal()
    {

        if (Physics.SphereCast(transform.position, 3f, Vector3.forward, out hit))
        {

        }
    }



}
