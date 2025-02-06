using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Content.Interaction;

public class KnobCombinationManager : MonoBehaviour
{
    [SerializeField] private XRKnob knob1;
    [SerializeField] private XRKnob knob2;
    [SerializeField] private XRKnob knob3;
    [SerializeField] private Transform coffreLid; // Partie supérieure du coffre
    [SerializeField] private float openAngle = 30f; // Angle d'ouverture
    [SerializeField] private float openDuration = 1f; // Durée de l'ouverture

    private bool isOpened = false;

    void Start()
    {
        if (knob1 != null) knob1.onValueChange.AddListener(CheckCombination);
        if (knob2 != null) knob2.onValueChange.AddListener(CheckCombination);
        if (knob3 != null) knob3.onValueChange.AddListener(CheckCombination);
    }

    void CheckCombination(float _)
    {
        int value1 = Mathf.RoundToInt(knob1.value * 10);
        int value2 = Mathf.RoundToInt(knob2.value * 10);
        int value3 = Mathf.RoundToInt(knob3.value * 10);

        if (value1 == 8 && value2 == 4 && value3 == 1 && !isOpened)
        {
            Debug.Log("✅ Coffre ouvert !");
            OpenCoffre();
            isOpened = true;
        }
    }

    void OpenCoffre()
    {
        if (coffreLid != null)
        {
            coffreLid.DOLocalRotate(new Vector3(openAngle, 0, 0), openDuration, RotateMode.LocalAxisAdd)
                .SetEase(Ease.OutQuad);
        }
    }

    void OnDestroy()
    {
        if (knob1 != null) knob1.onValueChange.RemoveListener(CheckCombination);
        if (knob2 != null) knob2.onValueChange.RemoveListener(CheckCombination);
        if (knob3 != null) knob3.onValueChange.RemoveListener(CheckCombination);
    }
}
