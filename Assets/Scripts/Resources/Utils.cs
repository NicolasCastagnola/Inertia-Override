using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public static class Utils
{
    public static async Task FlashSpriteRenderer(SpriteRenderer renderer, Color primaryColor, Color secondaryColor, int times, float tickRate)
    {
        for (int i = 0; i < times; i++)
        {
            renderer.color = primaryColor;
            
            await Task.Delay(secondsToMilisecondsConvertion(tickRate));

            renderer.color = secondaryColor;
        }
    } 

    public static int secondsToMilisecondsConvertion(float seconds)
    {
        var n = (int)(seconds * 1000f);
        
        return n;
    }
}

