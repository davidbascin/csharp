using System;
using System.IO;
using System.Text.Json;

public static class SettingsManager
{
    private static readonly string SettingsFilePath = Path.Combine(Environment.CurrentDirectory, "appsettings.json");
    public static AppSettings Settings { get; set; } = new AppSettings();
        
    public static string LoadSettings()
    {
        if (File.Exists(SettingsFilePath))
        {
            try
            {
                string json = File.ReadAllText(SettingsFilePath);
                Settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                return SettingsFilePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }
        }
        return string.Empty;
    }

    public static string SaveSettings()
    {
        try
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Settings, options);
            File.WriteAllText(SettingsFilePath, json);
            return SettingsFilePath;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving settings: {ex.Message}");
        }
        return string.Empty;
    }
}
