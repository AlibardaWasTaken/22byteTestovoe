using System.Collections;
using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{
    TextMeshProUGUI _timeText;

    float _lastRaceTimeUpdate = 0;

    private void Awake()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(UpdateTimeCO());
    }

    private WaitForSeconds _waitFor;
    IEnumerator UpdateTimeCO()
    {
        _waitFor = new WaitForSeconds(0.1f);
        while (true)
        {
            float TimeLeft = LevelControl.Instance.GetTime();

            if (_lastRaceTimeUpdate != TimeLeft)
            {
                int raceTimeMinutes = (int)Mathf.Floor(TimeLeft / 60);
                int raceTimeSeconds = (int)Mathf.Floor(TimeLeft % 60);

                _timeText.text = $"{raceTimeMinutes.ToString("00")}:{raceTimeSeconds.ToString("00")}";

                _lastRaceTimeUpdate = TimeLeft;
            }

            yield return _waitFor;
        }
    }
}
