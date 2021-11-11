using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [Serializable]
    public class MenuItem
    {
        public string itemName;
        public GameObject item;
    }

    public string menuName;
    public List<MenuItem> menuItems = new List<MenuItem>();
    public bool openMenu = false;

}
