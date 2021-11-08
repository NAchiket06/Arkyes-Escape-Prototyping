using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Quests
{

    public class UpdateQuest : MonoBehaviour
    {

        [SerializeField] QuestList quest;

        [SerializeField] TextMeshProUGUI QuestText;

        private void OnTriggerEnter(Collider other)
        {
            if(quest == null)
            {
                Debug.LogWarning("No quest scriptable object on trigger.");
                return;

            }
            if (QuestText != null)
                QuestText.text = quest.QuestObjective;

            else
                Debug.LogWarning("No TMPro text assigned to trigger. Unable to update Quest.");
        }
    }
}