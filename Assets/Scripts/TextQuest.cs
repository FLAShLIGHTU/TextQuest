using UnityEngine;
using UnityEngine.UI;


public class TextQuest : MonoBehaviour
{
    

    public Text ContentLabel;
    public StepSO GameStart;
    public Text HeaderLabel;
    public Image LocImage;

    private StepSO _currentStep;
    public StepSO FinishStep;

    

    
    private void Start()
    {
        SetStep(GameStart);
    }

    private void Update()
    {
        int nextStepNumber = GetStepNumber();

        if (nextStepNumber == -1)
        {
            return;
        }
        
        SetStep(nextStepNumber);
    }
    

    private void SetStep(StepSO nextStep)
    {

        if (nextStep == null)
        {
            return;
        }
        _currentStep = nextStep;
        ContentLabel.text = _currentStep.Content;
        HeaderLabel.text = _currentStep.LocName;
        LocImage.sprite = _currentStep.LocationImage;

    }
    
    private void SetStep(int nextStepNumberIndex)
    {
        if (IsValidIndex(nextStepNumberIndex))
        {
            return;
        }
        
        StepSO nextStep = _currentStep.Steps[nextStepNumberIndex];
        SetStep(nextStep);
    }

    private bool IsValidIndex(int nextStepNumberIndex)
    {
        return nextStepNumberIndex < 0 || nextStepNumberIndex > _currentStep.Steps.Length -1;
    }

    private int GetStepNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return 2;
        }

        return -1;
    }
    
}