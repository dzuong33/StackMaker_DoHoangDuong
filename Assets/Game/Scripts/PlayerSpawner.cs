using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public GameObject player;
    public Transform playerSpawnPoint;
    public static PlayerSpawner instance;
    public void Awake()
    {
            player = Instantiate(playerPrefab, playerSpawnPoint.transform.position, Quaternion.identity);
            player.name = ("PlayerClone");
    }
}
