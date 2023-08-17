using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> ������.</summary>
public class Bar : MonoBehaviour
{
    /// <summary> ����� ������.</summary>
    [SerializeField] private TMP_Text _text;

    /// <summary> ������������ ��������.</summary>
    public float MaxValue { get; private set; }

    /// <summary> ������� ��������.</summary>
    private float currentValue;

    /// <summary> ������� ��������.</summary>
    public float CurrentValue
    {
        get => currentValue;

        /// ����� �����������
        set
        {
            currentValue = Mathf.Max(Mathf.Min(value, MaxValue), 0);
            RefreshUI();
        }
    }

    /// <summary> �������� UI.</summary>
    private void RefreshUI()
    {
        StartCoroutine(Refresh());

        _text.text = $"{currentValue}/{MaxValue}";
    }

    /// <summary> �������� ������.</summary>
    /// <returns> ������ �������� �������� ������.</returns>
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

    /// <summary> ������������� ����.</summary>
    /// <param name="currentValue"> ������� ��������.</param>
    /// <param name="maxValue"> ������������ ��������.</param>
    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }
}
