using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AwnserRandom : MonoBehaviour
{
    [SerializeField]
    private Transform[] pos;
[SerializeField]
    private GameObject[] Cards;

    private int added;
    private int a;
    [SerializeField] 
     List<int> usedPos;
  

     int count = 4 - 0;
     private int[] deck;
     
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(Randommize());
    }

  public  void DisAbleBoxes()
    {
        for (int i = 0; i < Cards.Length; i++)
        {
            Cards[i].SetActive(false);
        }
        
    }

    void shuffel()
    {
       
         deck = new int[count];
        for (int i = 0; i < count; i++)
        {
            int j = Random.Range(0, i );

            deck[i] = deck[j];
            deck[j] = 0 + i;
        }
    }

    private void OnDisable()
    {
        usedPos.Clear();
        for ( int i = 0; i < deck.Length; i++)
        {
            deck[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Randommize()
    {
        yield return new WaitForSeconds(0.1f);
        shuffel();
        randomPos();
    }

    void randomPos()
    {


        for (int i = 0; i < Cards.Length; i++)
        {
          
            
            Cards[i].transform.position = pos[deck[i]].position;
            
        }

        
    }



   
}

