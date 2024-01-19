using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    public Slider menuBarSlider;
    public float menuBarSlideSpeed = 0.5f;
    public float menuBarSlideDelay = 0.1f;

    public GameObject[] screens;
    public Animator anim;

    private void Start()
    {
        StartCoroutine(MinimizeCycle());
    }

    public void ScoutButton() {
        StartCoroutine(MenuBarAnimation(2));
    }

    public void EditButton() {
        StartCoroutine(MenuBarAnimation(3));
    }

    public void BluetoothButton() {
        StartCoroutine(MenuBarAnimation(1));
    }

    public void MaximizeButton()
    {
        StartCoroutine(MinimizeCycle());
    }
    
    private IEnumerator MenuBarAnimation(int position) {
        if (menuBarSlider.value > position) {
            while (menuBarSlider.value > position) {
                menuBarSlider.value -= menuBarSlideSpeed;
                yield return new WaitForSeconds(menuBarSlideDelay);
            }
        } else if (menuBarSlider.value < position) {
            while (menuBarSlider.value < position) {
                menuBarSlider.value += menuBarSlideSpeed;
                yield return new WaitForSeconds(menuBarSlideDelay);
            }
        }

        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i + 1 == position);
            StartCoroutine(MinimizeNow());
        }
    }

    private IEnumerator MinimizeCycle()
    {
        anim.Play("Menu Bar Up");
        yield return new WaitForSeconds(5f);
        StartCoroutine(MinimizeNow());
    }
    
    private IEnumerator MinimizeNow()
    {
        yield return new WaitForSeconds(0.2f);
        anim.Play("Menu Bar Down");
    }
}
