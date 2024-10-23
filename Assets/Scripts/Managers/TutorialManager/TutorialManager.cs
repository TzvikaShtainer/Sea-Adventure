using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Tutorial UI Elements")]
    public Image tutorialImage;
    public TextMeshProUGUI tutorialText;
    public Button nextButton;
    public Button skipButton;
    public GameObject tutorialPanel;

    [Header("Tutorial Steps")]
    public List<TutorialStepSO> tutorialSteps;

    private int currentStepIndex = 0;
    private bool tutorialCompleted;
    
    private void Start()
    {
        tutorialCompleted = GameDataHandler.instance.GetTutorialCompleted();

        if (!tutorialCompleted)
        {
            ShowTutorial();
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    private void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
        LoadStep(currentStepIndex);
        
        nextButton.onClick.AddListener(NextStep);
        skipButton.onClick.AddListener(SkipTutorial);
    }
    
    private void LoadStep(int stepIndex)
    {
        if (stepIndex < tutorialSteps.Count)
        {
            TutorialStepSO step = tutorialSteps[stepIndex];
            tutorialImage.sprite = step.tutorialImage;
            tutorialText.text = step.tutorialText;
        }
        else
        {
            CompleteTutorial();
        }
    }

    private void NextStep()
    {
        currentStepIndex++;
        LoadStep(currentStepIndex);
        
        SoundManager.Instance.PlayClickSound();
    }
    
    private void SkipTutorial()
    {
        CompleteTutorial();
        
        SoundManager.Instance.PlayClickSound();
    }

    private void CompleteTutorial()
    {
        tutorialPanel.SetActive(false);
        //save data
        GameDataHandler.instance.SetTutorialCompleted(true);
        
        Time.timeScale = 1f;
    }
    
}
