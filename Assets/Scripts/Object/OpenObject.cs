using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    private Animator _animator;

    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void OpenDoor()
    {
        if (!isOpen)
        {
            _animator.SetTrigger("Open");
            isOpen = true;
        }
        else
        {
            _animator.SetTrigger("Close");
            isOpen = false;
        }
    }

  private void OnTriggerEnter(Collider other)
  
  {
      if (other.gameObject.CompareTag("Player"))
      {
          _animator.speed = 0;
          print("Col");
      }
  }


  private void OnTriggerExit(Collider other)
  {
      if (other.gameObject.CompareTag("Player"))
      {
          _animator.speed = 1;
       
      }
  }
}
