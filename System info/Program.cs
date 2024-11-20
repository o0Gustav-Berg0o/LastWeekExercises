using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

class SystemInfoDemo
{
    static void Main()
    {
        Console.WriteLine("=== System Information Tool ===\n");

        // Basic System Info
        Console.WriteLine("=== Basic System Information ===");
        //TODO display info about system using "Enviroment. "     

        // Drive Information
        Console.WriteLine("\n=== Drive Information ===");
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in allDrives)
        {
            if (drive.IsReady)
            {
                //TODO display info about drives 
                //Tip use FormatSize info when displaying sizes              
            }
        }

        // Process Information
        Console.WriteLine("\n=== Current Process Information ===");
        Process currentProcess = Process.GetCurrentProcess();
        //TODO - display info about current processes    

        // Network Information
        Console.WriteLine("\n=== Network Information ===");
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface ni in interfaces)
        {
            //TODO - display info about network interfaces 
            //Tip {FormatSize((long)ni.Speed / 8)            

            // Get IPv4 statistics
            IPv4InterfaceStatistics stats = ni.GetIPv4Statistics();
            //TODO - display info about traffic
            //Tip - use FormatSize            
        }

        // Running Processes Summary
        Console.WriteLine("\n=== Running Processes Summary ===");
        var processes = Process.GetProcesses()
            .OrderByDescending(p => p.WorkingSet64)
            .Take(5);

        Console.WriteLine("Top 5 Processes by Memory Usage:");
        foreach (var process in processes)
        {
           //TODO write out info
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Helper method to format bytes into readable sizes
    private static string FormatSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        double len = bytes;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}