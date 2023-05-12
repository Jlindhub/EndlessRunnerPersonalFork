using System.IO;
using UnityEngine;

namespace AudioSettingsSaver
{
    public class AudioSettings : IAudioSettings
    {
        public IAudioChannelSettings Music { get; set; }
        public IAudioChannelSettings Sfx { get; set; }

        public AudioSettings()
        {
            Music = new AudioChannelSettings(1f, false); // Default music settings
            Sfx = new AudioChannelSettings(1f, false); // Default SFX settings
        }
    }

    public class AudioChannelSettings : IAudioChannelSettings
    {
        public float Volume { get; set; }
        public bool Muted { get; set; }

        public AudioChannelSettings(float volume, bool muted)
        {
            Volume = volume;
            Muted = muted;
        }
    }

    public class AudioSettingsIO
    {
        private const string SettingsFileName = "audio_settings.json";

        // The current audio settings
        private AudioSettings _currentSettings;

        public AudioSettingsIO()
        {
            // Load the audio settings from the JSON file
            LoadSettings();
        }

        public void LoadSettings()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SettingsFileName);
            if (File.Exists(filePath))
            {
                // Read the JSON file and deserialize it into an instance of AudioSettings
                string json = File.ReadAllText(filePath);
                _currentSettings = JsonUtility.FromJson<AudioSettings>(json);
            }
            else
            {
                // Create a new instance of AudioSettings with default values
                _currentSettings = new AudioSettings();
                SaveSettings(); // Save the default settings to a JSON file
            }
        }

        public void SaveSettings()
        {
            // Serialize the current settings to JSON
            string json = JsonUtility.ToJson(_currentSettings, true);

            // Write the JSON to a file in the persistent data path
            string filePath = Path.Combine(Application.persistentDataPath, SettingsFileName);
            File.WriteAllText(filePath, json);
        }
    }
}