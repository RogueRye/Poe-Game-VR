using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehavior : MonoBehaviour {

    Renderer[] renders;
    Animator anim;
    bool isOpen;
    private void Start()
    {
        renders = GetComponentsInChildren<Renderer>();
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(var r in renders)
            {
                r.material.SetFloat("_MyPower", 4);
            }
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("pedestal"))
        {
            if (!Input.GetMouseButton(0))
            {
                transform.position = other.transform.position + Vector3.up * .5f;
                if (!isOpen)
                    Open();
            }
        }
    }

    private void Open()
    {
        isOpen = true;
        anim.Play("open");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var r in renders)
            {
                r.material.SetFloat("_MyPower", 30);
            }
        }
    }

}
