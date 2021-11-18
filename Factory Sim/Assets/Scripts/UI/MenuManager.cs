using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public List<MenuScreen> menus = new List<MenuScreen>();

    public static bool inMenu { get; set; } = false;
    public static Vector2 mousePosition { get; set; }

    #region UnityDefaults

    void Awake()
    {
        CloseAllMenus();
    }

    void Update()
    {
        if (inMenu)
        {
            mousePosition = Mouse.current.position.ReadValue();
        }
        else
        {
            mousePosition = Vector2.zero;
        }
    }

    #endregion

    #region MenuControls

    public MenuScreen FindMenu(string name)
    {
        foreach(MenuScreen menuScreen in menus)
        { 
            if (menuScreen.menuName == name)
            {
                return menuScreen;
            }
        }

        return null;
    }

    void OpenMenu(MenuScreen menuScreen)
    {
        menuScreen?.gameObject.SetActive(true);
        menuScreen.openMenu = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        inMenu = true;
    }

    void CloseMenu(MenuScreen menuScreen)
    {
        menuScreen?.gameObject.SetActive(false);
        menuScreen.openMenu = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CloseAllMenus()
    {
        foreach (MenuScreen menuScreen in menus)
        {
            CloseMenu(menuScreen);
        }

        inMenu = false;
    }

    #endregion

    #region Controls

    public void OnCloseMenu()
    {
        CloseAllMenus();
    }

    public void OnOpenBackpack()
    {
        MenuScreen menuScreen = FindMenu("Backpack");

        if (!menuScreen.openMenu)
        {
            OpenMenu(menuScreen);
        }
        else
        {
            CloseMenu(menuScreen);
            inMenu = false;
        }
    }

    public void OnOpenRadialMenu()
    {
        MenuScreen menuScreen = FindMenu("RadialMenu");
        
        if (!menuScreen.openMenu)
        {
            OpenMenu(menuScreen);
            menuScreen.GetComponentInChildren<RadialMenu>().Open();
        }
        else
        {
            CloseMenu(menuScreen);
            menuScreen.GetComponentInChildren<RadialMenu>().Close();
            inMenu = false;
        }
    }

    #endregion
}
