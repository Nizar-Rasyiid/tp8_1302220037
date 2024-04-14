using System;

namespace tp8
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();

            // Menerima inputan 1 dalam satuan suhu celcius
            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.Configuration.satuan_suhu);
            double inputSuhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            int inputHari = Convert.ToInt32(Console.ReadLine());

            // Pengkondisian pesan yang ingin ditampilkan
            if (config.Configuration.satuan_suhu == "celcius")
            {
                if ((inputSuhu >= 36.5 && inputSuhu <= 37.5) && inputHari < config.Configuration.batas_hari_demam)
                {
                    Console.WriteLine(config.Configuration.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.Configuration.pesan_ditolak);
                }
            }
            else if (config.Configuration.satuan_suhu == "fahrenheit")
            {
                if ((inputSuhu >= 97.7 && inputSuhu <= 99.5) && inputHari < config.Configuration.batas_hari_demam)
                {
                    Console.WriteLine(config.Configuration.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.Configuration.pesan_ditolak);
                }
            }

            // Membuat objek Covid untuk mengakses metode UbahSatuan
            CovidConfig.Covid covid = new CovidConfig.Covid();

            // Memanggil metode UbahSatuan untuk mengubah satuan suhu
            covid.UbahSatuan();

            // Meminta inputan suhu dan hari lagi setelah perubahan satuan suhu
            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.Configuration.satuan_suhu);
            inputSuhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            inputHari = Convert.ToInt32(Console.ReadLine());

            // Pengkondisian pesan yang ingin ditampilkan setelah perubahan satuan suhu
            if (config.Configuration.satuan_suhu == "celcius")
            {
                if ((inputSuhu >= 36.5 && inputSuhu <= 37.5) && inputHari < config.Configuration.batas_hari_demam)
                {
                    Console.WriteLine(config.Configuration.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.Configuration.pesan_ditolak);
                }
            }
            else if (config.Configuration.satuan_suhu == "fahrenheit")
            {
                if ((inputSuhu >= 97.7 && inputSuhu <= 99.5) && inputHari < config.Configuration.batas_hari_demam)
                {
                    Console.WriteLine(config.Configuration.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(config.Configuration.pesan_ditolak);
                }
            }
        }
    }
}
