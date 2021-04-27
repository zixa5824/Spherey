using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNCYCLEIMP : MonoBehaviour
{
    [SerializeField] private Transform sunTransform;
    [SerializeField] private Light sun;
    [SerializeField] private Vector3 hourMinuteSeconds = new Vector3(6f, 0f, 0f), hmsSunSet = new Vector3(18f, 0f, 0f);
    [SerializeField] private float intensityAtNoon = 1f, intensityAtSunSet = 0.5f, angleAtNoon;
    [SerializeField] private Color fogColorDay = new Color(159, 186, 206, 255), fogColorNight = Color.black;
    [NonSerialized] public float time;
    [SerializeField] private Transform starsTransform;
    [SerializeField] private Vector3 hmsStarsLight = new Vector3(19f, 30f, 0), hmsStarsExtinguish = new Vector3(03f, 30f, 0f);
    [SerializeField] private float starsFadeInTime = 7200f, starsFadeOutTime = 7200f;
    public float speed = 100;
    public int days = 0;
    private float intensity, rotation, prevRotation = -1f, sunSet, sunRise, sunDayRatio, fade, timeLight, timeExtinguish;
    private Vector3 dir;
    private Color tintColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    private Renderer rend;

    void Start()
    {
        time = HMS_to_Time(hourMinuteSeconds.x, hourMinuteSeconds.y, hourMinuteSeconds.z);
        sunSet = HMS_to_Time(hmsSunSet.x, hmsSunSet.y, hmsSunSet.z);
        sunRise = 86400 - sunSet;
        sunDayRatio = (sunSet - sunRise) / 43200f;
        dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angleAtNoon), Mathf.Sin(Mathf.Deg2Rad * angleAtNoon), 0f);
        starsFadeInTime /= speed;
        starsFadeOutTime /= speed;
        fade = 0;
        timeLight = HMS_to_Time(hmsStarsLight.x, hmsStarsLight.y, hmsStarsLight.z);
        timeExtinguish = HMS_to_Time(hmsStarsExtinguish.x, hmsStarsExtinguish.y, hmsStarsExtinguish.z);
        rend = starsTransform.GetComponent<ParticleSystem>().GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        if(time > 86400f)
        {
            days += 1;
            time -= 86400f;
        }
        if (prevRotation == -1f)
        {
            sunTransform.eulerAngles = Vector3.zero;
            prevRotation = 0f;
        }
        else
            prevRotation = rotation;
        rotation = (time - 21600f) / 86400 * 360f;
        sunTransform.Rotate(dir, rotation - prevRotation);
        starsTransform.Rotate(dir, rotation - prevRotation);
        //SUN INTENSITY
        if (time < sunRise) intensity = intensityAtSunSet * time / sunRise;
        else if (time < 43200f) intensity = intensityAtSunSet + (intensityAtNoon - intensityAtSunSet) * (time - sunRise) / (43200f - sunRise);
        else if (time < sunSet) intensity = intensityAtNoon - (intensityAtNoon - intensityAtSunSet) * (time - 43200f) / (sunSet - 43200f);
        else intensity = intensityAtSunSet - (1f - intensityAtSunSet) * (time - sunSet) / (84600f - sunSet);
        RenderSettings.fogColor = Color.Lerp(fogColorNight, fogColorDay, (float)Math.Pow(intensity, 1/2));
        if (sun != null) sun.intensity = intensity;

        if(Time_Falls_Between(time, timeLight, timeExtinguish))
        {
            fade += Time.deltaTime / starsFadeInTime;
            if (fade > 1f) fade = 1f;
        }
        else
        {
            fade -= Time.deltaTime / starsFadeOutTime;
            if (fade < 0f) fade = 0f;
        }
        tintColor.a = fade;
        rend.material.SetColor("_TintColor", tintColor);
    }
    private float HMS_to_Time(float hour, float minute, float second)
    {
        return 3600 * hour + 60 * minute + second; 
    }
    private bool Time_Falls_Between(float currTime, float startTime, float endTime)
    {
        if(startTime < endTime)
        {
            if (currTime >= startTime && currTime <= endTime) return true;
            else return false;
        }
        else
        {
            if (currTime < startTime && currTime > endTime) return false;
            else return true;
        }
    }
}
