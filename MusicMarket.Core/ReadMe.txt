
Veritabanı tablolarına karşılık gelecek olan classlarımızın ve gerekli olan arayüzlerin Interfacelerin bulunduğu sınıftır. 
Bu projede interfaceler Core katmanında ama bunları genellikle Data katmanında kullanılıyor.
-Core katmanında arayüzlerini tanımlama sebebi
Core proje, uygulama iş mantığı yapımızı, nasıl çalışması gerektiğini tutacaktır. Dolayısıyla, büyük bir teknoloji değişikliğine
ve hatta mantığa ihtiyacımız olursa, eski modülü çıkarabilir ve core proje interface ve modellerimizi değiştirerek yeni yapımızı
oluşturabiliriz.