using UnityEngine;
using System.Collections;
using System.IO.Ports;
public static class InputManager {
    public static SerialPort stream = new SerialPort("COM4", 115200);
    private static string recData = "";
    private static float fieldsize = 5.8f;
    private static int max = 4095;
    private static int[] masks = new int[] { 0x40, 0x80, 0x100, 0x200, 0x400, 0x800 };
    public static bool paused;
    public static void Init()
    {
        if (!stream.IsOpen)
        {
            paused = true;
            stream.Open();
            Debug.Log("Opened");
        }
    }


    public static float Blow()
    {
        string temp = stream.ReadLine();
        string[] parts = temp.Split(' ');
        float blow = float.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
        return blow;
    }
    public static Vector3 Gestic()
    {
        stream.Write("a");
        string temp = stream.ReadLine();


        string[] parts = temp.Split(' ');
        float[] accels = new float[3];

        for (int i = 0; i < 3; i++)
        {
            accels[i] = System.Convert.ToInt32(parts[i + 1], 16);
            if (accels[i] > 127)
                accels[i] -= 256;

           

            accels[i] /= 128;
        }
 

        return new Vector3(accels[0], accels[1], accels[2]);
    }
    public static Vector3 Accel()
    { //fuer tilt

        stream.Write("a");
        string temp = stream.ReadLine();
       
        
          string[] parts = temp.Split(' ');
          float[] accels = new float[3];

          for (int i = 0; i < 3; i++)
          {
              accels[i] = System.Convert.ToInt32(parts[i + 1], 16);
              if (accels[i] > 127)
                  accels[i] -= 256;

            if (accels[i] < -55)
                accels[i] = -55;
            else if (accels[i] > 55)
                accels[i] = 55;

            accels[i] /= 55;
          }
        Debug.Log(accels[2]);
          
        return new Vector3(accels[0], accels[1], accels[2]);
    }
    public static float Analog(int player)
    {
        player += 2; //Wechsel von Drehknöpfe zu Schieberegler;
        stream.Write("4");
        recData = stream.ReadLine();
        float zahl;
        string[] parts = recData.Split(' ');
        zahl = (System.Convert.ToInt32(parts[player], 16));
        zahl = -(((zahl *2* fieldsize )/ max) - fieldsize);

         
        return zahl;
    }

    public static bool Pressed(int button)
    {

        if (button < 1 || button > 6)
            return false;

        stream.Write("1");
        int buttonVal = System.Convert.ToInt32(stream.ReadLine(), 16);
        return ((masks[button - 1] & buttonVal) != 0);


    }
    public static void PressPaused()
    {
        if (Pressed(2))
        {
            if (paused)
                paused = false;
            else
                paused = true;
        }
    }
}
