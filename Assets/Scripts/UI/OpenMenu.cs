using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject openMenu, closeMenu;

    public void Open()
    {
        openMenu.SetActive(true);
        closeMenu.SetActive(false);
    }
}
