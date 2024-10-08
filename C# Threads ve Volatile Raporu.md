Threads / iş parçacığı = bir programın yürütme yolu. Gerçekleştirmek için birden fazla iş parçacığı kullanabiliriz böylelikle programımız farklı görevleri aynı anda yerine getirebilir. Geçerli iş parçacığı "main" iş parçacığıdır.
 
Volatile, C# dilindeki anahtar sözcüklerden biridir. Üye değişken bildirimi ile birlikte kullanılır. volatile anahtar sözcüğü yalnızca aşağıdaki değişken tipleri ile birlikte kullanılabilir.
1- Herhangi bir referans tipindeki değişken ile örneğin class, array ve interface gibi.

2- byte, sbyte, short, ushort, int, uint, char, float yada bool. türünden olan değişkenler ile.

3- byte, sbyte, short, ushort, int, yada uint türünden semboller içeren numaralandırmalar(enums) ile.

4- unsafe modda iken herhangi bir gösterici türü ile.

 Volatile ile bildirilen değişkenlere programın akışı sırasında her ihtiyaç duyulduğunda değişkenin gerçek yeri olan belleğe başvurulur. Aynı şekilde bir değişkene yeni bir değer yazılacağı zaman bu yazma işlemi hiç geciktirilmeden bellekteki yerine yazılır. Böylece volatile ile bildirilen değişkenler farklı iş parçacıkları yada prosesler tarafından ortak kullanılıyor olsada programın akışı içerisinde her zaman son versiyonu elde edilecektir. Çünkü bu değişkenlerin değeri her defasında bellekten çekilir.
