using UnityEngine;
    using System.Collections;
    using System.IO.Ports; 
public static class InputManager{
    public static SerialPort[] stream = {new SerialPort("COM0", 115200), new SerialPort("COM0", 115200) };
    
    private static string recData = "";
    private static float winkel = 150;
    private static float maxPow=5;
    private static int max = 4095;
    
    private static int[] masks = new int[] { 0x40, 0x80, 0x100, 0x200, 0x400, 0x800 };


    public static bool Init()
    {

        return Init(0) && Init(1);
    }

    public static bool Init(int player)
    {
        int cnt = 0;
        bool exc = true;
        while (exc && cnt < 10)
        {
            try
            {
                exc = false;
                if (!stream[player].IsOpen)
                {
                    stream[player].Open();
                    outLED(player);
                    setLED(player, 1);
                    Debug.Log("Opened" + player);
                }
            }
            catch (System.Exception e)
            {
                exc = true;
                stream[player] = new SerialPort("COM" + cnt, 115200);
                cnt++;
                Debug.Log("ADFSDf" + player);
            }
        }
        return !exc;
        
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
        {
            zahl = (int)((zahl * maxPow) / max *10)/10.0f;
        }
        else if (player == 1)
        {
            zahl = -(int)((((zahl * 2 * winkel) / max) - winkel));

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

    public static void setLED(int player, int stat)
    {
        string text = "l " + player + " " + stat + "\r\n";
        stream[player].Write(text);
        stream[player].ReadLine();
    }

    public static void outLED(int player)
    {
        
            for (int i = 0; i < 4; i++)
            {
                stream[player].Write("l " + i + " 0\r\n");
                stream[player].ReadLine();
            }
        
    }

}
