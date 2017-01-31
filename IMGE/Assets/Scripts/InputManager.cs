using UnityEngine;
    using System.Collections;
    using System.IO.Ports; 
public static class InputManager{
    public static SerialPort[] stream = new SerialPort[2]; //Coms selbst eintragen wenn Unity sich aufhängt
    
    private static string recData = "";
    private static float winkel = 150;
    private static float maxPow=5;
    private static int max = 4095;
    
    private static int[] masks = new int[] { 0x40, 0x80, 0x100, 0x200, 0x400, 0x800 };

    private static bool[] init = { false, false };
    private static bool init2=false;
    public static bool Init()
    {
        if(!init[0] && !init[1])
            return Init(0) && Init(1);
        return true;
    }
    public static void setStream(string a, string b)
    {
        if(!init[0])
            stream[0] = new SerialPort(a, 115200);
        if(!init[1])
            stream[1] = new SerialPort(b, 115200);
    }

    public static bool Init(int player)
    {
        if (!init[player])
        {
            int cnt = 2;
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
                }
            }
            init[player] = !exc;
            return !exc;
        }
        return true;
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
            zahl = maxPow - zahl;
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

    public static float blow(int player)
    {

        stream[player].Write("s");
        string temp = stream[player].ReadLine();
        string[] parts = temp.Split(' ');
        float blow = float.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
        return blow;
    }

}
