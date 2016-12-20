using UnityEngine;
using System.Collections;
using System.IO.Ports;
public static class InputManager {
    public static SerialPort[] stream = {new SerialPort("COM4", 115200), new SerialPort("COM5", 115200) };
    
    private static string recData = "";
    private static float winkel = 150;
    private static float maxPow=10;
    private static int max = 4095;
    private static int[] masks = new int[] { 0x40, 0x80, 0x100, 0x200, 0x400, 0x800 };


    public static void Init()
    {
        Init(0);
        Init(1);
    }

    public static void Init(int player)
    {
        if (!stream[player].IsOpen)
        {
            stream[player].Open();
            Debug.Log("Opened"+player);
        }
    }


    public static float Analog(int player, int regler)
    {
        //1,2 = Drehknöpfe - 3,4 = SchiebeRegler
        stream[player].Write("4");
        recData = stream[player].ReadLine();
        float zahl;
        string[] parts = recData.Split(' ');
        zahl = (System.Convert.ToInt32(parts[regler], 16));

        if (player == 0)
            zahl = (zahl * maxPow) / max;
        else if (player == 1)
        {
            zahl = -(((zahl * 2 * winkel) / max) - winkel);

        }
        
        return zahl;
    }

    public static bool Pressed(int player, int button)
    {

        if (button < 1 || button > 6)
            return false;

        stream[player].Write("1");
        int buttonVal = System.Convert.ToInt32(stream[player].ReadLine(), 16);
        return ((masks[button - 1] & buttonVal) != 0);


    }
  
}
