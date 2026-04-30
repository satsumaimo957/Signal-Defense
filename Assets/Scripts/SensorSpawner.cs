using System.Collections.Generic;
using UnityEngine;

public class SensorSpawner : MonoBehaviour
{
    public SensorData[] sensorTypes;

    private int selectedIndex = 0;

    private List<GameObject> sensors = new List<GameObject>();

    public int maxPoints = 10;
    private int currentPoints = 0;

    void Start()
    {
        pointText.text = currentPoints + " / " + maxPoints;
        costText.text = "Cost: " + sensorTypes[selectedIndex].cost;
    }

    public void SelectSensor(int index)
    {
        selectedIndex = index;
        UpdateUI();
    }

    public void SpawnSensor()
    {
        if (!GameManager.Instance.isPlacing) return;

        SensorData data = sensorTypes[selectedIndex];

        // ポイントチェック
        if (currentPoints + data.cost > maxPoints)
        {
            Debug.Log("ポイント不足");
            return;
        }

        GameObject sensor = Instantiate(data.prefab, new Vector3(0, 0.1f, 0), Quaternion.identity);

        SensorCost sc = sensor.GetComponent<SensorCost>();
        if (sc != null)
        {
            sc.cost = data.cost;
        }
        sensors.Add(sensor);

        currentPoints += data.cost;

        UpdateUI();
    }

    public void DeleteLastSensor()
    {
        if (sensors.Count == 0) return;

        GameObject last = sensors[sensors.Count - 1];

        SensorCost sc = last.GetComponent<SensorCost>();

        if (sc != null)
        {
            currentPoints -= sc.cost;
        }

        sensors.RemoveAt(sensors.Count - 1);
        Destroy(last);

        UpdateUI();
    }

    public TMPro.TextMeshProUGUI pointText;
    public TMPro.TextMeshProUGUI costText;

    void UpdateUI()
    {
        if (pointText != null)
        {
            pointText.text = currentPoints + " / " + maxPoints;
        }

        if (costText != null)
        {
            costText.text = "Cost: " + sensorTypes[selectedIndex].cost;
        }
    }
}