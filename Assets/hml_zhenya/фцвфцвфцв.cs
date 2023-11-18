using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundPlayer1 : MonoBehaviour
{
    [SerializeField] GameObject sound1;
	public GameObject soundd;
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
	Vector3 spawnPosition = new Vector3(1, 1, 1);
	GameObject newObject = Instantiate(soundd, spawnPosition, Quaternion.identity);
	    
        }

    }
}
