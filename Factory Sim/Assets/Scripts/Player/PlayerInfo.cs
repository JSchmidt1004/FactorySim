using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static Backpack backpack;
    public static Transform playerTransform;

    private void Start()
    {
        backpack = GetComponent<Backpack>();
    }

    void Update()
    {
        playerTransform = transform;
    }
}
