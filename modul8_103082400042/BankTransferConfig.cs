using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace modul8_103082400042
{
    public class TransferConfig
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class ConfirmationConfig
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    public class BankConfig
    {
        public string lang { get; set; }
        public TransferConfig transfer { get; set; }
        public List<string> methods { get; set; }
        public ConfirmationConfig confirmation { get; set; }
    }

    public class BankTransferConfig
    {
        public BankConfig config;
        public string path = Directory.GetCurrentDirectory() + "/bank_transfer_config.json";

        public BankTransferConfig()
        {
            try { ReadConfigFile(); }
            catch { SetDefault(); WriteConfigFile(); }
        }

        private void SetDefault()
        {
            config = new BankConfig
            {
                lang = "en",
                transfer = new TransferConfig { threshold = 25000000, low_fee = 6500, high_fee = 15000 },
                methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                confirmation = new ConfirmationConfig { en = "yes", id = "ya" }
            };
        }

        private void ReadConfigFile()
        {
            string jsonString = File.ReadAllText(path);
            config = JsonSerializer.Deserialize<BankConfig>(jsonString);
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(path, jsonString);
        }
    }
}