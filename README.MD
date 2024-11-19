# PracticeLinqGroupJoin

Bu proje, LINQ `GroupJoin` metodunu kullanarak öğrenci ve sınıf listelerini birleştiren basit bir C# uygulamasıdır.


## Kullanılan Teknolojiler

- .NET 9.0
- C#

## Kurulum ve Çalıştırma

1. Bu projeyi klonlayın:
    ```sh
    git clone https://github.com/ahmetemreari/PracticeLinqGroupJoin.git
    cd PracticeLinqGroupJoin
    ```

2. Projeyi derleyin:
    ```sh
    dotnet build
    ```

3. Uygulamayı çalıştırın:
    ```sh
    dotnet run --project PracticeLinqGroupJoin
    ```

## Kod Açıklaması

### `Ogrenci` Sınıfı

```csharp
public class Ogrenci
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public int SinifId { get; set; }
}
```

### `Sinif` Sınıfı

```csharp
public class Sinif
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
```

### `Program` Sınıfı

```csharp
public class Program
{
    public static void Main()
    {
        // Öğrenci ve sınıf listeleri oluşturuluyor
        List<Ogrenci> ogrenciler = new List<Ogrenci>
        {
            new Ogrenci { Id = 1, Ad = "Ali", Soyad = "Veli", SinifId = 1 },
            new Ogrenci { Id = 2, Ad = "Ayşe", Soyad = "Fatma", SinifId = 2 },
            new Ogrenci { Id = 3, Ad = "Bihter", Soyad = "Ziyagil", SinifId = 3 },
            new Ogrenci { Id = 4, Ad = "Behlul", Soyad = "Haznedar", SinifId = 3 },
            new Ogrenci { Id = 5, Ad = "Adnan", Soyad = "Ziyagil", SinifId = 3 },
            new Ogrenci { Id = 6, Ad = "Firdevs", Soyad = "Yoreoglu", SinifId = 3 }
        };

        List<Sinif> siniflar = new List<Sinif>
        {
            new Sinif { Id = 1, Name = "1A" },
            new Sinif { Id = 2, Name = "2B" },
            new Sinif { Id = 3, Name = "3C" }
        };

        // Öğrenci ve sınıf listeleri GroupJoin metodu ile birleştiriliyor
        var sonuc = siniflar.GroupJoin(ogrenciler,
            sinif => sinif.Id,
            ogrenci => ogrenci.SinifId,
            (sinif, ogrenci) => new
            {
                SinifAdi = sinif.Name,
                Ogrenciler = ogrenci
            });

        // Sonuçlar ekrana yazdırılıyor
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
```

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir issue açın.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır.
