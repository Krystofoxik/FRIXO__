﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FRIXO
{
    class Program
    {
        static string path = "?";
        static bool run = true;
        static char prefix = '>';
        static ConsoleColor c = ConsoleColor.Red;
        static ConsoleColor bc = ConsoleColor.Black;
        static Random rr = new Random();
        static void Main(string[] args)
        {
            Console.Clear();
            Intro();
            path = Environment.GetCommandLineArgs()[0];
            //path = path.Substring(path.Length - path.Split('\\')[path.Split('\\').Length - 1].Length, path.Split('\\')[path.Split('\\').Length - 1].Length - 1);
            path = path.Substring(0, path.Length - path.Split('\\')[path.Split('\\').Length - 1].Length - 1);

            bool pre = true;
            bool nl = true;
            bool cmd = true;

            while (run)
            {
                Color(ConsoleColor.White);
                if (pre) Console.Write(path + prefix);
                Color(c);
                BColor(bc);

                string input = Console.ReadLine();

                switch (input.Split(' ')[0])
                {
                    case "os":
                        Console.WriteLine($"Operation System:  {Environment.OSVersion}");
                        if (Environment.Is64BitOperatingSystem)
                            Console.WriteLine("\t\t   64 Bit Operating System\n");
                        else
                            Console.WriteLine("\t\t   32 Bit Operating System\n");

                        Console.WriteLine("SystemDirectory:  {0}\n", Environment.SystemDirectory);
                        break;

                    case "prefix":
                        prefix = input.Split(' ')[1][0];
                        break;

                    case "pre":
                        pre = (pre) ? false : true;
                        break;

                    case "nl":
                        nl = (nl) ? false : true;
                        break;

                    case "cmd":
                        cmd = (cmd) ? false : true;
                        break;

                    case "cd":
                        string pa = (input.Split(' ').Length == 1) ? Console.ReadLine() : input.Split(' ')[1];

                        if (pa == "..") path = path.Substring(0, path.Length - path.Split('\\')[path.Split('\\').Length - 1].Length - 1);
                        else
                        {
                            if (Directory.Exists(path + "\\" + pa)) path += "\\" + pa;
                            else if (Directory.Exists(pa)) path = pa;
                        }
                        break;

                    case "ls":
                        string[] dir = Directory.GetFileSystemEntries(path);
                        //string[] files = Directory.GetFiles(path);
                        foreach (string i in dir)
                        {
                            string y = i.Substring(i.Length - i.Split('\\')[i.Split('\\').Length - 1].Length, i.Split('\\')[i.Split('\\').Length - 1].Length);
                            if (y.Split(".").Length < 2) Color(ConsoleColor.White);
                            else Color(c);
                            Console.Write("█ " + y + " ");
                            if (nl) Console.WriteLine();
                        }
                        Console.WriteLine();
                        break;

                    case "drive":
                        Console.WriteLine("LogicalDrives:\n");
                        foreach (System.IO.DriveInfo DriveInfo1 in System.IO.DriveInfo.GetDrives())
                        {
                            try
                            {
                                Console.WriteLine("\t Drive: {0}\n\t\t VolumeLabel: " +
                                  "{1}\n\t\t DriveType: {2}\n\t\t DriveFormat: {3}\n\t\t " +
                                  "TotalSize: {4}\n\t\t AvailableFreeSpace: {5}\n",
                                  DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                                  DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);

                                long vysledek = DriveInfo1.AvailableFreeSpace * 100 / DriveInfo1.TotalSize;
                                Color(ConsoleColor.White);
                                Console.Write("{");

                                for (int u = 0; u < 100 - vysledek; u++)
                                {
                                    Console.Write("█");
                                }

                                Color(c);
                                for (int y = 0; y < vysledek; y++)
                                {
                                    Console.Write("█");
                                }

                                Color(ConsoleColor.White);
                                Console.Write("} ");
                                Color(c);
                                Console.Write(vysledek + "% space left \n\n");

                            }
                            catch
                            {
                            }
                        }
                        break;

                    case "matrix":
                        Console.CursorVisible = false;
                        for (int i = 0; i < int.Parse(input.Split(' ')[1]); i++)
                        {
                            for (int j = 1; j <= 7; j++)
                            {
                                for (int s = 1; s <= 8; s++)
                                {
                                    if (rr.Next(10) > 5)
                                    {
                                        Color(c);
                                    }
                                    else
                                    {
                                        RColor(c);
                                    }

                                    int n = rr.Next(2);
                                    Console.Write(n);
                                }
                                if (j != 7)
                                {
                                    Console.Write(" ");
                                }
                            }
                        }
                        Console.CursorVisible = true;
                        break;

                    case "color":
                        c = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input.Split(' ')[1]);
                        break;

                    case "bcolor":
                        bc = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), input.Split(' ')[1]);
                        break;

                    case "clear":
                        BColor(bc);
                        Console.Clear();
                        Intro();
                        break;

                    case "":
                        break;

                    default:
                        Console.Title = input;
                        if (cmd) Cmd(input);
                        break;
                }


            }
            Console.WriteLine(SystemInformation());

            Console.ReadKey();
        }

        static void RColor(ConsoleColor c)
        {
            switch (c)
            {
                case ConsoleColor.Black:
                    Color(ConsoleColor.White);
                    break;
                case ConsoleColor.DarkBlue:
                    Color(ConsoleColor.Blue);
                    break;
                case ConsoleColor.DarkGreen:
                    Color(ConsoleColor.Green);
                    break;
                case ConsoleColor.DarkCyan:
                    Color(ConsoleColor.Cyan);
                    break;
                case ConsoleColor.DarkRed:
                    Color(ConsoleColor.Red);
                    break;
                case ConsoleColor.DarkMagenta:
                    Color(ConsoleColor.Magenta);
                    break;
                case ConsoleColor.DarkYellow:
                    Color(ConsoleColor.Yellow);
                    break;
                case ConsoleColor.Gray:
                    Color(ConsoleColor.DarkGray);
                    break;
                case ConsoleColor.DarkGray:
                    Color(ConsoleColor.Gray);
                    break;
                case ConsoleColor.Blue:
                    Color(ConsoleColor.DarkBlue);
                    break;
                case ConsoleColor.Green:
                    Color(ConsoleColor.DarkGreen);
                    break;
                case ConsoleColor.Cyan:
                    Color(ConsoleColor.DarkCyan);
                    break;
                case ConsoleColor.Red:
                    Color(ConsoleColor.DarkRed);
                    break;
                case ConsoleColor.Magenta:
                    Color(ConsoleColor.DarkMagenta);
                    break;
                case ConsoleColor.Yellow:
                    Color(ConsoleColor.DarkYellow);
                    break;
                case ConsoleColor.White:
                    Color(ConsoleColor.Black);
                    break;
                default:
                    break;
            }

        }
        static void Color(ConsoleColor c)
        {
            Console.ForegroundColor = c;
        }
        static void BColor(ConsoleColor c)
        {
            Console.BackgroundColor = c;
        }

        static void Intro()
        {
            BColor(bc);
            Color(ConsoleColor.White);
            Console.WriteLine("FRIXO v1\n");
            Color(c);
        }

        static void Cmd(string arg)
        {
            /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = arg;
            process.StartInfo = startInfo;
            process.Start();*/

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + arg);

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            // wrap IDisposable into using (in order to release hProcess) 
            using (Process process = new Process())
            {
                process.StartInfo = procStartInfo;
                process.Start();

                // Add this: wait until process does its work
                //process.WaitForExit();

                // and only then read the result
                string result = process.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
            }
        }

        private static string SystemInformation()
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            try
            {
                StringBuilder1.AppendFormat("Operation System:  {0}\n", Environment.OSVersion);
                if (Environment.Is64BitOperatingSystem)
                    StringBuilder1.AppendFormat("\t\t  64 Bit Operating System\n");
                else
                    StringBuilder1.AppendFormat("\t\t  32 Bit Operating System\n");
                StringBuilder1.AppendFormat("SystemDirectory:  {0}\n", Environment.SystemDirectory);
                StringBuilder1.AppendFormat("ProcessorCount:  {0}\n", Environment.ProcessorCount);
                StringBuilder1.AppendFormat("UserDomainName:  {0}\n", Environment.UserDomainName);
                StringBuilder1.AppendFormat("UserName: {0}\n", Environment.UserName);
                //Drives
                StringBuilder1.AppendFormat("LogicalDrives:\n");
                foreach (System.IO.DriveInfo DriveInfo1 in System.IO.DriveInfo.GetDrives())
                {
                    try
                    {
                        StringBuilder1.AppendFormat("\t Drive: {0}\n\t\t VolumeLabel: " +
                          "{1}\n\t\t DriveType: {2}\n\t\t DriveFormat: {3}\n\t\t " +
                          "TotalSize: {4}\n\t\t AvailableFreeSpace: {5}\n",
                          DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                          DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);
                    }
                    catch
                    {
                    }
                }
                StringBuilder1.AppendFormat("SystemPageSize:  {0}\n", Environment.SystemPageSize);
                StringBuilder1.AppendFormat("Version:  {0}", Environment.Version);
            }
            catch
            {
            }
            return StringBuilder1.ToString();
        }
    }
}