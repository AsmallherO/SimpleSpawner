using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomScript : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<SpawnScript>().speed = Random.Range(10f,500f);
        FindObjectOfType<SpawnScript>().Distance = Random.Range(50f,1400f);
        FindObjectOfType<SpawnScript>().timeToSpawn = Random.Range(0.05f,3f);
        FindObjectOfType<SpawnScript>().Spawn();
    }
}
