using System.Collections.Generic;
using UnityEngine;

namespace Quests
{ 
    [CreateAssetMenu(fileName ="Quest#",menuName ="Quests/New Quest",order =0)]
    public class QuestList:ScriptableObject
    {
        [TextArea(1,10)]
        public string QuestObjective;
        
    }
}