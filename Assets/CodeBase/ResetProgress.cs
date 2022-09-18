using UnityEngine;

namespace CodeBase
{
    public class ResetProgress : MonoBehaviour
    {
        private const string Progress = "Progress";

        public void Reset()
        {
            if (PlayerPrefs.HasKey(Progress))
            {
                Debug.Log("Progress reset!");
                PlayerPrefs.DeleteKey(Progress);
            }
            else
                Debug.Log("The " + Progress + " does not exist");
        }
    }
}
