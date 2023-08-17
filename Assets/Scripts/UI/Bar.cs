using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Полоса.</summary>
public class Bar : MonoBehaviour
{
    /// <summary> Текст полосы.</summary>
    [SerializeField] private TMP_Text _text;

    /// <summary> Максимальное значение.</summary>
    public float MaxValue { get; private set; }

    /// <summary> Текущее значение.</summary>
    private float currentValue;

    /// <summary> Текущее значение.</summary>
    public float CurrentValue
    {
        get => currentValue;

        /// ПОТОМ ЗАПРИВАТИТЬ
        set
        {
            currentValue = Mathf.Max(Mathf.Min(value, MaxValue), 0);
            RefreshUI();
        }
    }

    /// <summary> Обновить UI.</summary>
    private void RefreshUI()
    {
        StartCoroutine(Refresh());

        _text.text = $"{currentValue}/{MaxValue}";
    }

    /// <summary> Обновить полосу.</summary>
    /// <returns> Плавно изменяет значение полосы.</returns>
    private IEnumerator Refresh()
    {
        var image = GetComponent<Image>();
        float lerpSpeed = 3f;
        do
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, CurrentValue / MaxValue, Time.deltaTime * lerpSpeed);
            yield return null;
        } while (Mathf.Abs(CurrentValue / MaxValue - image.fillAmount) > 0.001f);
        image.fillAmount = CurrentValue / MaxValue;
    }

    /// <summary> Инициализация бара.</summary>
    /// <param name="currentValue"> Текущее значение.</param>
    /// <param name="maxValue"> Максимальное значение.</param>
    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }
}
