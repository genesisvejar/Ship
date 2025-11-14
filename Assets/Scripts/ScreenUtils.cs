using Unity.VisualScripting;
using UnityEngine;

public static class ScreenUtils
{
    #region Fields

    // saved to support resolution changes
    static int screenWidth;
    static int screenHeight;

    // cached for efficient boundary checking
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;


        public static float ScreenLeft
    {
        get  { return screenLeft; }

    }

    
        public static float ScreenRight
    {
        get  { return screenRight; }

    }

    
        public static float ScreenTop
    {
        get  { return screenTop; }

    }

        public static float ScreenBottom
    {
        get  { return screenBottom; }

    }
    public static void Initialize() {
    
    screenWidth = Screen.width;
    screenHeight = Screen.height;

    float screenZ = -Camera.main.transform.position.z;
    Vector3 bottonLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0,0,screenZ));
    Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3 (screenWidth, screenHeight,screenZ));
  
    screenLeft = bottonLeftCorner.x;
    screenRight = topRightCorner.x;
    screenBottom = bottonLeftCorner.y;
    screenTop = topRightCorner.y;
}

#endregion
}