using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public GameObject[] screens;
    public Slider menuBarSlider;
    public Animator anim;

    public int sliderSpeed = 1;
    private int position = 200;

    private bool move = false;

    private void Start()
    {
        StartCoroutine(MenuBarTimeout());
    }

    public void BluetoothButton()
    {
        move = true;
        position = 100;
    }

    public void ScoutButton()
    {
        move = true;
        position = 200;
    }

    public void EditButton()
    {
        move = true;
        position = 300;
    }

    public void MaximizeButton()
    {
        StartCoroutine(MenuBarTimeout());
    }

    private void MoveSlider(int position)
    {
        if (!move) return;
        if (menuBarSlider.value < position)
        {
            menuBarSlider.value += sliderSpeed;
        } 
        else if (menuBarSlider.value > position)
        {
            menuBarSlider.value -= sliderSpeed;
        }
        else
        {
            move = false;

            for (var i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive((i + 1) * 100 == position);
            }
        }
    }
    
    private void FixedUpdate()
    {
        MoveSlider(position);
    }

    private IEnumerator MenuBarTimeout()
    {
        anim.Play("Menu Bar Up");
        yield return new WaitForSeconds(4f);
        anim.Play("Menu Bar Down");
    }
}
