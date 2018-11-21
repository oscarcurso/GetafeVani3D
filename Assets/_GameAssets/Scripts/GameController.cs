using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private const string XPOS = "xPos";
    private const string YPOS = "yPos";

    public static void StorePosition(Vector2 position) {

        PlayerPrefs.SetFloat(XPOS, position.x);
        PlayerPrefs.SetFloat(YPOS, position.y);

    }

    public static Vector2 GetPosition() {
        Vector2 position = new Vector2();

        if(PlayerPrefs.HasKey(XPOS) && PlayerPrefs.HasKey(YPOS)) {
            float x = PlayerPrefs.GetFloat(XPOS);
            float y = PlayerPrefs.GetFloat(YPOS);
            position = new Vector2(x, y);


        } else {
            position = Vector2.zero;
        }
        return position;

    }



}
