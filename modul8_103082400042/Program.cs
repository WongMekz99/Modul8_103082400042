using System;
using modul8_103082400042;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig bConfig = new BankTransferConfig();

        // 1. Cek Bahasa
        if (bConfig.config.lang == "en")
            Console.Write("Please insert the amount of money to transfer: ");
        else
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");

        int nominal = int.Parse(Console.ReadLine());

        // 2. Hitung Biaya Transfer 
        int fee = (nominal <= bConfig.config.transfer.threshold) ?
                   bConfig.config.transfer.low_fee : bConfig.config.transfer.high_fee;
        int total = nominal + fee;

        if (bConfig.config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}\nTotal amount = {total}");
            Console.WriteLine("Select transfer method:");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}\nTotal biaya = {total}");
            Console.WriteLine("Pilih metode transfer:");
        }

        // 3. Print Methods dengan Numbering 
        for (int i = 0; i < bConfig.config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {bConfig.config.methods[i]}");
        }
        int pilihMethod = int.Parse(Console.ReadLine());

        // 4. Konfirmasi 
        string confirmCode = (bConfig.config.lang == "en") ?
                              bConfig.config.confirmation.en : bConfig.config.confirmation.id;

        if (bConfig.config.lang == "en")
            Console.Write($"Please type \"{confirmCode}\" to confirm the transaction: ");
        else
            Console.Write($"Ketik \"{confirmCode}\" untuk mengkonfirmasi transaksi: ");

        string inputConfirm = Console.ReadLine();

        if (inputConfirm == confirmCode)
            Console.WriteLine(bConfig.config.lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        else
            Console.WriteLine(bConfig.config.lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
    }
}