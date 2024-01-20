using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public GameObject[] screens;
    
    public Slider menuBarSlider;
    public float menuBarSlideSpeed = 0.5f;
    public float menuBarSlideDelay = 0.1f;
    
    public Animator anim;

    private void Start()
    {
        StartCoroutine(Cycle());
    }

    public void BluetoothButton() {
        StartCoroutine(MenuBarAnimation(1));
        ChangeScreen(1);
    }
    
    public void ScoutButton() {
        StartCoroutine(MenuBarAnimation(2));
        ChangeScreen(2);
    }

    public void EditButton() {
        StartCoroutine(MenuBarAnimation(3));
        ChangeScreen(3);
    }

    public void MaximizeButton()
    {
        StartCoroutine(Cycle());
    }

    public void ChangeScreen(int screen)
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i + 1 == screen);
        }
    }
    
    private IEnumerator MenuBarAnimation(int position) {
        if (menuBarSlider.value > position) {
            while (menuBarSlider.value > position) {
                menuBarSlider.value -= menuBarSlideSpeed;
                yield return new WaitForSeconds(menuBarSlideDelay);
            }
        } else if (menuBarSlider.value < position)
        {
            while (menuBarSlider.value < position)
            {
                menuBarSlider.value += menuBarSlideSpeed;
                yield return new WaitForSeconds(menuBarSlideDelay);
            }
        }
    }

    private IEnumerator Cycle()
    {
        anim.Play("Menu Bar Up");
        yield return new WaitForSeconds(5f);
        anim.Play("Menu Bar Down");
    }
}
