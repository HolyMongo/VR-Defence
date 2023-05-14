using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSo;
    [SerializeField] private EnemySO enemySo;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Slider slider;
    [SerializeField] TextMeshProUGUI barText;
    [SerializeField] private Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (playerSo != null)
        {
            slider.maxValue = playerSo.Hp();
            slider.value = playerSo.Hp();
        }
        else
        {
            slider.maxValue = enemySo.Hp();
            slider.value = enemySo.Hp();
        }
        barText.text = slider.value + "/" + slider.maxValue;
    }

    public void TakeDamage(float _damage)
    {
        if (canvas != null)
        {
            slider.value -= _damage;
            barText.text = slider.value + "/" + slider.maxValue;
        }
    }

    public void GainHealth(float _health)
    {
        if(canvas != null)
        {
            slider.value += _health;
            barText.text = slider.value + "/" + slider.maxValue;
        }
    }

    private void LateUpdate()
    {
        if(enemySo != null)
        {
            if (canvas != null)
            {
                canvas.transform.LookAt(canvas.transform.position + cam.transform.forward);
            }
        }
    }
}
