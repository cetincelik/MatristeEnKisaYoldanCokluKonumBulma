using System;
using System.Collections.Generic;
// En kısayı bulan C# programı
// belirli bir kaynak hücre arasındaki yol
// bir hedef hücreye.
namespace MatristeEnKisaYoldanCokluKonumBulma
{
    class Program
    {
        static int satirSayisi = 9;
        static int sutunSayisi = 10;
        static List<int> baslangicX = new List<int>();
        static List<int> baslangicY = new List<int>();
        // Matris hücre koordinatlarını saklamak için
        public class koordinat
        {
            public int x;
            public int y;
            public koordinat(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        };
        // BFS'de kullanılan kuyruk için bir Veri Yapısı
        public class kuyrukDugumu
        {
            // Bir hücrenin koordinatları
            public koordinat hucreKoordinati;
            // hücrenin kaynağa uzaklığı
            public int hucreninKaynagaOlanUzakligi;
            public kuyrukDugumu(koordinat hucreKoordinati, int hucreninKaynagaOlanUzakligi)
            {
                this.hucreKoordinati = hucreKoordinati;
                this.hucreninKaynagaOlanUzakligi = hucreninKaynagaOlanUzakligi;
            }
        };
        // verilen hücrenin (satır, sütun) olup olmadığını kontrol edin
        // geçerli bir hücre veya değil.
        static bool isValid(int satir, int sutun)
        {
            // satır numarası ise true döndür ve
            // sütun numarası aralıkta
            return (satir >= 0) && (satir < satirSayisi) &&
                (sutun >= 0) && (sutun < sutunSayisi);
        }
        // Bu diziler satır ve sütun almak için kullanılır
        // belirli bir hücrenin 4 komşusunun sayısı
        static int[] satirNumarasi = { -1, 0, 0, 1 };
        static int[] sutunNumarasi = { 0, -1, 1, 0 };
        // arasındaki en kısa yolu bulma işlevi
        // belirli bir kaynak hücreden bir hedef hücreye.
        static int BFS(int[,] matris, koordinat kaynak, int x, int y)
        {
            // kaynak ve hedef hücreyi kontrol et
            // matrisin değeri 1'dir
            if (matris[kaynak.x, kaynak.y] != 1 || matris[x, y] != 1)
                return -1;
            bool[,] ziyaret = new bool[satirSayisi, sutunSayisi];
            // Kaynak hücreyi ziyaret edildi olarak işaretle
            ziyaret[kaynak.x, kaynak.y] = true;
            // BFS için bir kuyruk oluşturun
            Queue<kuyrukDugumu> q = new Queue<kuyrukDugumu>();
            // Kaynak hücrenin mesafesi 0
            kuyrukDugumu s = new kuyrukDugumu(kaynak, 0);
            q.Enqueue(s); // Kaynak hücreyi kuyruğa al
            // Kaynak hücreden başlayarak bir BFS yapın
            while (q.Count != 0)
            {
                kuyrukDugumu curr = q.Peek();
                koordinat hucreKoordinati = curr.hucreKoordinati;
                // Hedef hücreye ulaştıysak,
                // İşimiz bitti
                if (hucreKoordinati.x == x && hucreKoordinati.y == y)
                {
                    return curr.hucreninKaynagaOlanUzakligi;
                }
                // Aksi takdirde ön hücreyi boşaltın
                // kuyrukta ve kuyruğa gir
                // bitişik hücreleri
                q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int satir = hucreKoordinati.x + satirNumarasi[i];
                    int sutun = hucreKoordinati.y + sutunNumarasi[i];
                    // bitişik hücre geçerliyse, yolu vardır
                    // ve henüz ziyaret edilmedi, kuyruğa alın.
                    if (isValid(satir, sutun) &&
                            matris[satir, sutun] == 1 &&
                    !ziyaret[satir, sutun])
                    {
                        // hücreyi ziyaret edildi olarak işaretle ve kuyruğa al
                        ziyaret[satir, sutun] = true;
                        kuyrukDugumu Adjcell = new kuyrukDugumu
                                (new koordinat(satir, sutun),
                                        curr.hucreninKaynagaOlanUzakligi + 1);
                        q.Enqueue(Adjcell);
                    }
                }
            }
            // Hedefe ulaşılamıyorsa -1 döndür
            return -1;
        }
        // Sürücü Kodu
        static void Main(string[] args)
        {
            HedefBul(0, 0);

        }
        private static void HedefBul(int baslamaKoordinatiX, int baslamaKoordinatiY)
        {
            // x = sütun
            // y = satır
            int[,] matris =
            {
                    {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                    {1, 0, 1, 0, 1, 1, 1, 0, 1, 1},
                    {1, 1, 1, 0, 1, 1, 0, 1, 0, 1},
                    {0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
                    {1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                    {1, 0, 1, 1, 1, 1, 0, 1, 0, 0},
                    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                    {1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
                    {1, 1, 1, 0, 0, 1, 1, 0, 0, 0}
                };
            koordinat baslangic = new koordinat(baslamaKoordinatiX, baslamaKoordinatiY);
            koordinat hedef1 = new koordinat(1, 1);
            koordinat hedef2 = new koordinat(2, 2);
            koordinat hedef3 = new koordinat(8, 1);
            koordinat hedef4 = new koordinat(5, 5);
            koordinat hedef5 = new koordinat(8, 6);
            koordinat hedef6 = new koordinat(0, 1);
            koordinat hedef7 = new koordinat(5, 4);
            baslangicX.Add(baslangic.x);
            baslangicY.Add(baslangic.y);
            List<int> hedefXKordinatlari = new List<int>();
            List<int> hedefYKordinatlari = new List<int>();

            hedefXKordinatlari.Add(hedef1.x);
            hedefXKordinatlari.Add(hedef2.x);
            hedefXKordinatlari.Add(hedef3.x);
            hedefXKordinatlari.Add(hedef4.x);
            hedefXKordinatlari.Add(hedef5.x);
            hedefXKordinatlari.Add(hedef6.x);
            hedefXKordinatlari.Add(hedef7.x);

            hedefYKordinatlari.Add(hedef1.y);
            hedefYKordinatlari.Add(hedef2.y);
            hedefYKordinatlari.Add(hedef3.y);
            hedefYKordinatlari.Add(hedef4.y);
            hedefYKordinatlari.Add(hedef5.y);
            hedefYKordinatlari.Add(hedef6.y);
            hedefYKordinatlari.Add(hedef7.y);

            Console.WriteLine("Hedef koordinat sayısı: " + hedefXKordinatlari.Count);
            Console.WriteLine("**************************** ");
            int gidilenHedefX = baslamaKoordinatiX;
            int gidilenHedefY = baslamaKoordinatiY;
            int elemanSayisi = hedefYKordinatlari.Count;
            for (int j = 0; j < elemanSayisi; j++)
            {
                int oncelikliHedefYolUzunlugu = 1000;
                for (int i = 0; i < hedefXKordinatlari.Count; i++)
                {
                    int hedefX = hedefXKordinatlari[i];
                    int hedefY = hedefYKordinatlari[i];
                    int hucreninKaynagaOlanUzakligi = BFS(matris, baslangic, hedefX, hedefY);
                    if (hucreninKaynagaOlanUzakligi != -1)
                    {
                        if (oncelikliHedefYolUzunlugu >= hucreninKaynagaOlanUzakligi)
                        {
                            oncelikliHedefYolUzunlugu = hucreninKaynagaOlanUzakligi;
                            gidilenHedefX = hedefXKordinatlari[i];
                            gidilenHedefY = hedefYKordinatlari[i];
                        }
                        if ((i + 1) == hedefXKordinatlari.Count)
                        {
                            Console.WriteLine("X: " + gidilenHedefX + "   Y:  " + gidilenHedefY);
                            Console.WriteLine("En Kısa Yol: " + oncelikliHedefYolUzunlugu);
                            int arananIndexX = hedefXKordinatlari.IndexOf(gidilenHedefX);
                            int arananIndexY = hedefYKordinatlari.IndexOf(gidilenHedefY);
                            Console.WriteLine("X'in anlık bulunduğu index : " + arananIndexX +
                                              "   Y'in anlık bulunduğu index : " + arananIndexY);
                            hedefXKordinatlari.RemoveAt(arananIndexX);
                            hedefYKordinatlari.RemoveAt(arananIndexY);
                            baslangic = new koordinat(gidilenHedefX, gidilenHedefY);
                            Console.WriteLine("*****************************");
                        }
                    }
                    else
                    {
                        Console.WriteLine("X: " + hedefXKordinatlari[i] + "   Y:  " + hedefYKordinatlari[i]);
                        Console.WriteLine("En Kısa Yol mevcut değil.");
                        Console.WriteLine("X'in bulunduğu index : " + i +
                                          "   Y'in bulunduğu index : " + i);
                        hedefXKordinatlari.RemoveAt(i);
                        hedefYKordinatlari.RemoveAt(i);
                        Console.WriteLine("*********************************");
                    }

                }
            }
        }
    }
}


