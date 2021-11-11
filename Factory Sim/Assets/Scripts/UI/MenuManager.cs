using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public List<MenuScreen> menus = new List<MenuScreen>();
    public PlayerMovement player;

    public static bool inMenu = false;

    GameControls gameControls;

    #region UnityDefaults

    void Awake()
    {
        gameControls = new GameControls();

        CloseAllMenus();
    }

    void OnEnable()
    {
        gameControls.Enable();
    }

    void OnDisable()
    {
        gameControls.Disable();
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
            player.GetComponent<Backpack>().UpdateSlots();
        }
        else
        {
            CloseMenu(menuScreen);
            inMenu = false;
        }
    }

    #endregion
}
