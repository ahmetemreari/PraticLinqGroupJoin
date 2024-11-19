using System;
using System.Collections.Generic;
using System.Linq;

public class Ogrenci
{
    //Öğrenci sınıfı oluşturuldu. Öğrenci sınıfının özellikleri tanımlandı. 
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty; // Varsayılan değer atandı
    public string Soyad { get; set; } = string.Empty; // Varsayılan değer atandı
    public int SinifId { get; set; } // ClassId yerine SinifId olarak değiştirildi
}

public class Sinif
{
    //Class Sınıfı oluşturuldu. Class sınıfının özellikleri tanımlandı.
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Varsayılan değer atandı
}

public class Program
{
    public static void Main()
    {
        //Öğrenci listesi oluşturuldu.
        List<Ogrenci> ogrenciler = new List<Ogrenci>
        {
            new Ogrenci { Id = 1, Ad = "Ali", Soyad = "Veli", SinifId = 1 },
            new Ogrenci { Id = 2, Ad = "Ayşe", Soyad = "Fatma", SinifId = 2 },
            new Ogrenci { Id = 3, Ad = "Bihter", Soyad = "Ziyagil", SinifId = 3 },
            new Ogrenci { Id = 4, Ad = "Behlul", Soyad = "Haznedar", SinifId = 3 },
            new Ogrenci { Id = 5, Ad = "Adnan", Soyad = "Ziyagil", SinifId = 3 },
            new Ogrenci { Id = 6, Ad = "Firdevs", Soyad = "Yoreoglu", SinifId = 3 }
        };

        //Sınıf listesi oluşturuldu.
        List<Sinif> siniflar = new List<Sinif>
        {
            new Sinif { Id = 1, Name = "Ben" },
            new Sinif { Id = 2, Name = "Kurtlar Vadisi" },
            new Sinif { Id = 3, Name = "Aski Memnu" }
        };

        //Öğrenci ve Sınıf listeleri GroupJoin metodu ile birleştirildi.
        var sonuc = siniflar.GroupJoin(ogrenciler, //Birleştirilecek olan koleksiyon
            sinif => sinif.Id, //Birleştirme işlemi yapılacak olan sınıf Id
            ogrenci => ogrenci.SinifId, //Birleştirme işlemi yapılacak olan öğrenci SinifId
            (sinif, ogrenci) => new //Birleştirme işlemi sonucunda oluşacak yeni bir koleksiyon
            {
                SinifAdi = sinif.Name, //Sınıf adı
                Ogrenciler = ogrenci //Sınıfa ait öğrenciler
            });

        //Sonuç
        foreach (var item in sonuc)
        {
            Console.WriteLine("Sınıf Adı: " + item.SinifAdi);
            foreach (var ogrenci in item.Ogrenciler)
            {
                Console.WriteLine("Öğrenci Adı: " + ogrenci.Ad + " " + ogrenci.Soyad);
            }
            Console.WriteLine("************************************");
        }
    }
}