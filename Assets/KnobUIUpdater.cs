using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class KnobUIUpdater : MonoBehaviour
{
    [SerializeField] private XRKnob knob;
    [SerializeField] private TextMeshProUGUI knobValueText;

    void Start()
    {
        if (knob != null)
        {

            knob.onValueChange.AddListener(UpdateKnobUI);
            UpdateKnobUI(knob.value);
        }
    }

    void UpdateKnobUI(float value)
    {
        if (knobValueText != null)
        {

            knobValueText.text = Mathf.RoundToInt(value * 10).ToString();
        }
    }


    void OnDestroy()
    {
        if (knob != null)
        {
            knob.onValueChange.RemoveListener(UpdateKnobUI);
        }
    }
}
