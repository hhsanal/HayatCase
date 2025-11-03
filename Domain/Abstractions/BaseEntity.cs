namespace Domain.Abstractions;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    // burada int yerine guid kullanma sebebim sensör verilerini kaydedeceğiz int değişken 2 milyar küsürden sonra yetersiz kalacaktır.
    // Sensör verilreide üretim ortamında bu değeri geçme ihtimali yüksek
    public Guid Id { get; set; }

    //oluşturulma tarihi aslında verinin sensörden alındığı tarih olacaktır verinin üretildiği tarih değil
    // verinin üretildiği tarihi ayrıca istediğimizde ekleyebiliriz. iki tarih farkını alarak data pipeline da ki gecikmeyi basit olarak hesaplayabiliriz
    public DateTimeOffset CreatedDate { get; set; }

}
