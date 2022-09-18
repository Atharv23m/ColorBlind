using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public Transform[] Orbs;

    public Tower[] Towers = new Tower[5];

    public GameObject player;

    private Player plyr;

    public Canvas menu, crosshair, defeat;

    public ColorManager clrmanager;

    public TextMeshProUGUI textbox;

    public Enemy[] enemies;
    private void Start()
    {
        plyr = player.GetComponent<Player>();
        plyr.SetOrbs(Orbs);
        Time.timeScale = 0;
        crosshair.enabled = false;
        defeat.enabled = false;

    }
    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            Towers[i].SetColor(clrmanager.clrs[i]);
        }
    }
    public void PlayerFoundbyTower()
    {
        foreach(Enemy enemy in enemies)
        {
            enemy.SetDestination();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = true;
            crosshair.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            textbox.text = "";
        }
    }

    public void PressStart()
    {
        menu.enabled = false;
        crosshair.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Defeat()
    {
        menu.enabled = false;
        crosshair.enabled = false;
        defeat.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        plyr.ResetT();
        foreach (Enemy e in enemies)
            e.ResetT();
        menu.enabled = true;
        crosshair.enabled = false;
        defeat.enabled = false;
    }
}
        
