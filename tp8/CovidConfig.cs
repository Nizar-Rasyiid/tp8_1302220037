using System;
using System.IO;
using System.Text.Json;

namespace tp8
{
    internal class CovidConfig
    {
        public class Config
        {
            public string satuan_suhu { get; set; }
            public int batas_hari_demam { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }

            public Config() { }

            public Config(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
            {
                this.satuan_suhu = satuan_suhu;
                this.batas_hari_demam = batas_hari_demam;
                this.pesan_ditolak = pesan_ditolak;
                this.pesan_diterima = pesan_diterima;
            }
        }


        public class Covid
        {
            public Config configuration;
            public const string ConfigName = "D:\\KPL C#\\tp8\\tp8\\bin\\Debug\\net8.0\\covid_config.json";
            public Covid()
            {
                try
                {
                    configuration = ReadConfigFile();
                }
                catch (FileNotFoundException)
                {
                    SetDefault();
                    WriteNewConfigFile();
                }
            }

            public void SetDefault()
            {
                configuration = new Config("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    "Anda diperbolehkan masuk ke dalam gedung ini");
            }

            // Method untuk membaca file konfigurasi
            private Config ReadConfigFile()
            {
                string configJsonData = File.ReadAllText(ConfigName);
                return JsonSerializer.Deserialize<Config>(configJsonData);
            }

            public void WriteNewConfigFile()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(configuration, options);
                File.WriteAllText(ConfigName, jsonString);
            }
            public void UbahSatuan()
            {
                if (configuration.satuan_suhu == "celcius")
                {
                    configuration.satuan_suhu = "fahrenheit";
                }
                else
                {
                    configuration.satuan_suhu = "celcius";
                }
            }

        }
        public Config Configuration => new Covid().configuration;
    }
}
