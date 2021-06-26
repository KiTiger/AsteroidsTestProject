using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidsTestProject.Settings
{
    [CreateAssetMenu(fileName = "GameViewConfiguration", menuName = "AsteroidsTestProject/GameViewConfiguration", order = 1)]
    public class GameViewConfiguration : ScriptableObject
    { 
        public List<GameViewData> visualМodes;
    }
}
