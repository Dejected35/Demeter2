using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player", order = 0)]
    public class PlayerData : ScriptableObject
    {
        public string Name = "Şinasi";
        public string Surname  = "Beyazsakal";
        public string Id  = "123456";
        public string Adress = "Örnekköy Mah.";
    }
}