//7. Pemesanan Tiket Bus
using System;
using System.Collections.Generic;

class RNurwahidTravel
{
    static Dictionary<int, (string, int)> ruteHarga = new Dictionary<int, (string, int)>
    {
        {1, ("Jakarta - Bandung", 100000)},
        {2, ("Jakarta - Surabaya", 200000)},
        {3, ("Jakarta - Yogyakarta", 150000)},
        {4, ("Jakarta - Semarang", 120000)},
        {5, ("Jakarta - Malang", 180000)},
        {6, ("Bandung - Surabaya", 220000)},
        {7, ("Bandung - Yogyakarta", 170000)},
        {8, ("Bandung - Semarang", 140000)},
        {9, ("Bandung - Malang", 200000)},
        {10, ("Surabaya - Yogyakarta", 160000)}
    };

    static Dictionary<int, List<string>> jadwalArmada = new Dictionary<int, List<string>>
    {
        {1, new List<string> {"09:00", "12:00", "15:00"}},
        {2, new List<string> {"07:00", "13:00", "19:00"}},
        {3, new List<string> {"08:00", "11:00", "14:00"}},
        {4, new List<string> {"06:00", "12:00", "18:00"}},
        {5, new List<string> {"05:00", "10:00", "17:00"}},
        {6, new List<string> {"09:30", "13:30", "16:30"}}
        
    };

    static void Main()
    {
        Console.WriteLine("=== R NURWAHID Travel ===\n");
        bool isRunning = true;
        while (isRunning)
        {
            
            Console.WriteLine("Pilih Opsi:");
            Console.WriteLine("1. Pemesanan tiket");
            Console.WriteLine("2. Daftar harga tiket");
            Console.WriteLine("3. Jadwal Keberangkatan");
            Console.WriteLine("4. Keluar\n");

            Console.Write("Pilihan Anda (1/2/3/4): ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    PemesananTiket();
                    break;
                case "2":
                    DaftarHargaTiket();
                    break;
                case "3":
                    JadwalKeberangkatan();
                    break;
                case "4":
                    Console.WriteLine("Terima kasih telah menggunakan R NURWAHID Travel. Sampai jumpa!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan masukkan 1, 2, 3, atau 4.");
                    break;
            }
        }
    }

    static void PemesananTiket()
    {
       Console.WriteLine("\n=== Pemesanan Tiket ===");
        Console.Write("Masukkan nama pemesan: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan jumlah tiket: ");
        int jumlah = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Pilih rute:");
        foreach (var rute in ruteHarga)
        {
            Console.WriteLine($"{rute.Key}. {rute.Value.Item1}: Rp{rute.Value.Item2}");
        }
        Console.Write("Pilihan rute: ");
        int pilihanRute = Convert.ToInt32(Console.ReadLine());

        if (ruteHarga.TryGetValue(pilihanRute, out var detailRute))
        {
            Console.WriteLine("Pilih armada:");
            foreach (var armada in jadwalArmada)
            {
                Console.WriteLine($"Armada {armada.Key}");
            }
            Console.Write("Pilihan armada: ");
            int pilihanArmada = Convert.ToInt32(Console.ReadLine());

            if (jadwalArmada.TryGetValue(pilihanArmada, out var jadwal))
            {
                Console.WriteLine("Pilih waktu keberangkatan:");
                for (int i = 0; i < jadwal.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {jadwal[i]}");
                }
                Console.Write("Pilihan waktu: ");
                int pilihanWaktu = Convert.ToInt32(Console.ReadLine()) - 1;

                if (pilihanWaktu >= 0 && pilihanWaktu < jadwal.Count)
                {
                    int totalHarga = jumlah * detailRute.Item2;
                    Console.WriteLine($"Total harga untuk {jumlah} tiket adalah: Rp{totalHarga}");
                    Console.WriteLine($"Tiket atas nama {nama} sebanyak {jumlah} telah berhasil dipesan dengan total harga Rp{totalHarga}.");
                    Console.WriteLine($"Armada {pilihanArmada} akan berangkat pada {jadwal[pilihanWaktu]}.");
                }
                else
                {
                    Console.WriteLine("Waktu keberangkatan tidak valid. Silakan pilih waktu yang tersedia.");
                }
            }
            else
            {
                Console.WriteLine("Armada tidak valid. Silakan pilih armada yang tersedia.");
            }
        }
        else
        {
            Console.WriteLine("Rute tidak valid. Silakan pilih rute yang tersedia.");
        }
    }

    

    static void DaftarHargaTiket()
    {
        Console.WriteLine("\n=== Daftar Harga Tiket ===");
        foreach (var rute in ruteHarga)
        {
            Console.WriteLine($"{rute.Key}. {rute.Value.Item1}: Rp{rute.Value.Item2}");
        }
    }

    static void JadwalKeberangkatan()
    {
        Console.WriteLine("\n=== Jadwal Keberangkatan ===");
        foreach (var jadwal in jadwalArmada)
        {
            Console.WriteLine($"Armada {jadwal.Key}: {String.Join(", ", jadwal.Value)}");
        }
    }
}