/*
 * --------------------------------------------
 * 
 * Autor : Nikola Stjepanović
 * Projekt : Benzinska crpka
 * Predmet : Osnove Programiranja
 * Ustanova : VŠMTI
 * Godina : 2019/2020.
 * 
 * ---------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace Konstrukcijske_vjezbe___Benzinska_crpka
{
    class Program
    {
        public struct Racun
        {
            public string datumkreiranja;
            public string nazivgoriva;
            public double kolicinagoriva;
            public double cijenagoriva;
            public double idzaposlenika;
            public Racun(string dk, string ng, double kg, double cg, double idz)
            {
                datumkreiranja = dk;
                nazivgoriva = ng;
                kolicinagoriva = kg;
                cijenagoriva = cg;
                idzaposlenika = idz;
            }
        }
        public struct Login
        {
            public double id;
            public string username;
            public string password;
            public Login(double ID, string us, string pw)
            {
                id = ID;
                username = us;
                password = pw;
            }
        }
        public struct KolicinaGoriva
        {
            public string ImeZaposlenika;
            public double ProdanoGorivo;
            public KolicinaGoriva(string IZ, double PG)
            {
                ImeZaposlenika = IZ;
                ProdanoGorivo = PG;
            }
        }
        public static void GlavniIzbornik()
        {
            /*
             * --------------------------------------------
             * 
             * Ova funkcija je glavni izbornik
             * 
             * 
             * --------------------------------------------
             */
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            StreamWriter iLogovi = new StreamWriter(put, true);
            iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup GLAVNOM IZBORNIKU!");
            iLogovi.Close();
            Console.WriteLine("================================");
            Console.WriteLine("1 - IZRADI RAČUN               =");
            Console.WriteLine("2 - STANJE U SPREMNICIMA       =");
            Console.WriteLine("3 - PREGLED RAČUNA             =");
            Console.WriteLine("4 - AŽURIRAJ STANJE SPREMNIKA  =");
            Console.WriteLine("5 - STATISTIKA PRODANOG GORIVA =");
            Console.WriteLine("6 - ODJAVA                     =");
            Console.WriteLine("================================");
            double odabir;
            Console.Write("Unesite broj da pristupite tom izborniku : ");
            odabir = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            switch (odabir)
            {
                case 1:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku 1 - IZRADI RAČUN");
                    iLogovi.Close();
                    IzradiRacun();
                    break;
                case 2:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku 2 - STANJE U SPREMNICIMA");
                    iLogovi.Close();
                    StanjeuSpremnicima();
                    break;
                case 3:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku 3 - PREGLED RAČUNA");
                    iLogovi.Close();
                    SortiranjeRacuna();
                    break;
                case 4:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku 4 - AŽURIRAJ STANJE SPREMNIKA");
                    iLogovi.Close();
                    AzurirajStanje();
                    break;
                case 5:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku 5 - STATISTIKA PRODANOG GORIVA");
                    iLogovi.Close();
                    StatistikaProdanogGoriva();
                    break;
                case 6:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Korisnik se odjavio!");
                    iLogovi.Close();
                    NakonOdjave();
                    break;
                default:
                    GlavniIzbornik();
                    break;
            }
        }
        public static void IzradiRacun()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija služi za odabir kojoj vrsti goriva
             * treba izraditi račun
             * 
             * --------------------------------------------
             */
            double a;
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            Console.WriteLine("=========================================");
            Console.WriteLine("VRSTE GORIVA KOJE PRODAJEMO:            =");
            Console.WriteLine("1. Dizel                                =");
            Console.WriteLine("2. Benzin                               =");
            Console.WriteLine("=========================================");
            Console.Write("Unesite tip goriva koji želite prodati : ");
            a = Convert.ToDouble(Console.ReadLine());
            switch (a)
            {
                case 1:
                    StreamWriter iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku za izradu računa za Dizel gorivo.");
                    iLogovi.Close();
                    Console.Clear();
                    UpisRacunaDizel();
                    NakonAkcije();
                    break;
                case 2:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku za izradu računa za Benzin gorivo.");
                    iLogovi.Close();
                    Console.Clear();
                    UpisRacunaBenzin();
                    NakonAkcije();
                    break;
            }
        }
        public static void UpisRacunaDizel()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija služi za upis iz liste u .xml
             * datoteku.
             * 
             * --------------------------------------------
             */
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
            double kolicina = Convert.ToDouble(oXml.DocumentElement.SelectSingleNode("/Spremnici/Dizel/stanje").InnerText);
            Console.WriteLine("Ukupna količina preostalog dizel goriva : {0} ", kolicina);
            Console.WriteLine("=======================================================");
            double kg, cg, idz;
            string ng;
            Console.Write("");
            ng = "dizel";
            Console.Write("Unesite količinu goriva u litrama koje kupac želi kupiti : ");
            kg = double.Parse(Console.ReadLine());
            DateTime dkr = DateTime.Now;
            string dk = dkr.ToString();
            if (kg < 5)
            {
                Console.WriteLine("Nije moguće prodati količinu goriva manju od 5 litara! Pritisnite enter za povratak u glavni izborinik!");
                Console.ReadKey();
                GlavniIzbornik();
            }
            if (kolicina < kg)
            {
                Console.WriteLine("Nema dovoljno goriva u spremniku! Pritisnite enter za povratak u glavni izborinik!");
                Console.ReadKey();
                GlavniIzbornik();
            }
            cg = kg * 8.78;
            double popust = 0;
            if (kg >= 100)
            {
                popust = cg * 0.1;
                Console.WriteLine("Cijena je umanjena za 10% ");
            }
            cg = cg - popust;
            string putr = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\pomocnitxt.txt";
            StreamReader iPomocni = new StreamReader(putr);
            string sadrzajtxta = iPomocni.ReadToEnd();
            idz = Double.Parse(sadrzajtxta);
            iPomocni.Close();
            List<Racun> iRacun = new List<Racun>()
            {
                new Racun()
                {
                    datumkreiranja=dk,
                    nazivgoriva=ng,
                    kolicinagoriva=kg,
                    cijenagoriva=cg,
                    idzaposlenika=idz
                }
            };
            XDocument doc = XDocument.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XElement xRacuni = doc.Root;
            foreach (Racun Racun in iRacun)
            {
                XElement noviRacun = new XElement("Racun", new object[]
                {
                new XElement("datumkreiranja", Racun.datumkreiranja),
                new XElement("nazivgoriva", Racun.nazivgoriva),
                new XElement("kolicinagoriva", Racun.kolicinagoriva.ToString()),
                new XElement("cijenagoriva", Racun.cijenagoriva.ToString()),
                new XElement("idzaposlenika", Racun.idzaposlenika)
                });
                xRacuni.Add(noviRacun);
                doc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Kreiran račun za Dizel gorivo.");
                iLogovi.Close();
            }
            double novostanje = kolicina - kg;
            string stanjenovo = novostanje.ToString();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
            xDoc.DocumentElement.SelectSingleNode("/Spremnici/Dizel/stanje").InnerText = stanjenovo;
            xDoc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
        }
        public static void UpisRacunaBenzin()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija služi za upis iz liste u .xml
             * datoteku.
             * 
             * --------------------------------------------
             */
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
            double kolicina = Convert.ToDouble(oXml.DocumentElement.SelectSingleNode("/Spremnici/Benzin/stanje").InnerText);
            Console.WriteLine("Ukupna količina preostalog benzin goriva : {0} ", kolicina);
            Console.WriteLine("=======================================================");
            double kg, cg, idz;
            string ng;
            Console.Write("");
            ng = "benzin";
            Console.Write("Unesite količinu goriva u litrama koje kupac želi kupiti : ");
            kg = double.Parse(Console.ReadLine());
            DateTime dkr = DateTime.Now;
            string dk = dkr.ToString();
            if (kg < 5)
            {
                Console.WriteLine("Nije moguće prodati količinu goriva manju od 5 litara! Pritisnite enter za povratak u glavni izborinik!");
                Console.ReadKey();
                GlavniIzbornik();
            }
            if (kolicina < kg)
            {
                Console.WriteLine("Nema dovoljno goriva u spremniku! Pritisnite enter za povratak u glavni izborinik!");
                Console.ReadKey();
                GlavniIzbornik();
            }
            cg = kg * 9.65;
            double popust = 0;
            if (kg >= 100)
            {
                popust = cg * 0.15;
                Console.WriteLine("Cijena je umanjena za 15% ");
            }
            cg = cg - popust;
            string putr = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\pomocnitxt.txt";
            StreamReader iPomocni = new StreamReader(putr);
            string sadrzajtxta = iPomocni.ReadToEnd();
            idz = Double.Parse(sadrzajtxta);
            iPomocni.Close();
            List<Racun> iRacun = new List<Racun>()
            {
                new Racun()
                {
                    datumkreiranja=dk,
                    nazivgoriva=ng,
                    kolicinagoriva=kg,
                    cijenagoriva=cg,
                    idzaposlenika=idz
                }
            };
            XDocument doc = XDocument.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XElement xRacuni = doc.Root;
            foreach (Racun Racun in iRacun)
            {
                XElement noviRacun = new XElement("Racun", new object[]
                {
                new XElement("datumkreiranja", Racun.datumkreiranja),
                new XElement("nazivgoriva", Racun.nazivgoriva),
                new XElement("kolicinagoriva", Racun.kolicinagoriva.ToString()),
                new XElement("cijenagoriva", Racun.cijenagoriva.ToString()),
                new XElement("idzaposlenika", Racun.idzaposlenika)
                });
                xRacuni.Add(noviRacun);
                doc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Kreiran račun za Benzin gorivo.");
                iLogovi.Close();
            }
            double novostanje = kolicina - kg;
            string stanjenovo = novostanje.ToString();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
            xDoc.DocumentElement.SelectSingleNode("/Spremnici/Benzin/stanje").InnerText = stanjenovo;
            xDoc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
        }
        public static void StanjeuSpremnicima()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za odabir spremnika u kojem
             * želimo provjeriti stanje preostale
             * količine goriva.
             * 
             * --------------------------------------------
             */
            double a;
            Console.WriteLine("========================================================");
            Console.WriteLine("Odaberite u kojem spremniku želite provjeriti stanje : =");
            Console.WriteLine("1. DIZEL                                               =");
            Console.WriteLine("2. BENZIN                                              =");
            Console.WriteLine("========================================================");
            Console.Write("Vaš odabir : ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("========================================================");
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            switch (a)
            {
                case 1:
                    StreamWriter iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku za provjeru stanja dizel goriva");
                    iLogovi.Close();
                    StanjeDizela();
                    break;
                case 2:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku za provjeru stanja benzin goriva");
                    iLogovi.Close();
                    StanjeBenzina();
                    break;
                default:
                    StanjeuSpremnicima();
                    break;
            }
            NakonAkcije();
        }
        public static void StanjeDizela()
        {
            /*
             * --------------------------------------------
             * Funkcija učitava datoteku spremnici.xml
             * i na ekran ispisuje ukupnu količinu
             * preostalog goriva u spremniku za dizel gorivo
             * 
             * --------------------------------------------
             */
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
            double kolicina = Convert.ToDouble(oXml.DocumentElement.SelectSingleNode("/Spremnici/Dizel/stanje").InnerText);
            Console.WriteLine("Ukupna količina preostalog dizel goriva : {0} ", kolicina);
        }
        public static void StanjeBenzina()
        {
            /*
             * --------------------------------------------
             * Funkcija učitava datoteku spremnici.xml
             * i na eran ispisuje ukupnu količinu preostalog
             * goriva u spremniku za benzinsko gorivo.
             * 
             * --------------------------------------------
             */
            XmlDocument oXml = new XmlDocument();
            oXml.Load("spremnici.xml");
            double kolicina = Convert.ToDouble(oXml.DocumentElement.SelectSingleNode("/Spremnici/Benzin/stanje").InnerText);
            Console.WriteLine("Ukupna količina preostalog benzin goriva : {0} ", kolicina);
        }
        public static void SortiranjeRacuna()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za ispis računa iz racuni.xml
             * datoteke koji su sortirani po datumu kada su
             * izrađeni.
             * 
             * --------------------------------------------
             */
            List<Racun> lIsta = new List<Racun>();
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XmlNodeList xList = oXml.SelectNodes("/Racuni/Racun");
            foreach (XmlNode oNode in xList)
            {
                string dk1 = oNode["datumkreiranja"].InnerText;
                string ng1 = oNode["nazivgoriva"].InnerText;
                double kg1 = Convert.ToDouble(oNode["kolicinagoriva"].InnerText);
                double cg1 = Convert.ToDouble(oNode["cijenagoriva"].InnerText);
                double z1 = Convert.ToDouble(oNode["idzaposlenika"].InnerText);
                lIsta.Add(new Racun(dk1, ng1, kg1, cg1, z1));
            }
            lIsta = lIsta.OrderBy(x => Convert.ToDateTime(x.datumkreiranja)).ToList();
            for (int i = 0; i < lIsta.Count; i++)
            {
                Console.WriteLine("Datum kreiranja : {0} ", lIsta[i].datumkreiranja);
                Console.WriteLine("Naziv goriva : {0} ", lIsta[i].nazivgoriva);
                Console.WriteLine("Kolicina goriva : {0} ", lIsta[i].kolicinagoriva);
                Console.WriteLine("Cijena goriva : {0} ", lIsta[i].cijenagoriva);
                Console.WriteLine("ID zaposlenika : {0} ", lIsta[i].idzaposlenika);
                Console.WriteLine("=============================");
            }
            NakonAkcije();
        }
        public static void AzurirajStanje()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za odabir kojem gorivu želimo
             * ažuritati stanje u spremniku.
             * 
             * 
             * --------------------------------------------
             */
            double a;
            Console.WriteLine("Unesite kojoj vrsti goriva želite promjenit spremnik : ");
            Console.WriteLine("1. DIZEL");
            Console.WriteLine("2. BENZIN");
            a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.Clear();
                    AzurirajStanjeDizel();
                    break;
                case 2:
                    Console.Clear();
                    AzurirajStanjeBenzin();
                    break;
                default:
                    AzurirajStanje();
                    break;
            }
        }
        public static void AzurirajStanjeDizel()
        {
            /*
            * --------------------------------------------
            * Ova funkcija služi za izmjenu količine goriva
            * u datoteci spremnici.xml (konkretno stanje
            * dizela)
            * 
            * --------------------------------------------
            */
            Console.WriteLine("Unesite ukupnu količinu goriva koja se nalazi u spremniku ! ");
            double novostanje;
            novostanje = Convert.ToDouble(Console.ReadLine());
            if (novostanje < 20001 && novostanje > 1000)
            {
                string stanjenovo = novostanje.ToString();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
                xDoc.DocumentElement.SelectSingleNode("/Spremnici/Dizel/stanje").InnerText = stanjenovo;
                xDoc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
                string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Izmjenjena količina dizela u spremniku!");
                iLogovi.Close();
                Console.WriteLine("Uspješno ste izvršili izmjenu dostupne količine goriva u spremniku ! ");
            }
            else
            {
                Console.WriteLine("Unesli ste količinu goriva koja je manja od 1000 litara, ili premašuje maximalan kapacitet spremnika koji iznosi 20000 litara ! ");
            }
            NakonAkcije();
        }
        public static void AzurirajStanjeBenzin()
        {
            /*
             * --------------------------------------------
             * Ova funkcija služi za izmjenu količine goriva
             * u datoteci spremnici.xml (konkretno stanje
             * benzina)
             * 
             * --------------------------------------------
             */
            Console.WriteLine("Unesite ukupnu količinu goriva koja se nalazi u spremniku : ");
            double novostanje;
            novostanje = Convert.ToDouble(Console.ReadLine());
            if (novostanje < 20001 && novostanje > 1000)
            {
                string stanjenovo = novostanje.ToString();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
                xDoc.DocumentElement.SelectSingleNode("/Spremnici/Benzin/stanje").InnerText = stanjenovo;
                xDoc.Save(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\spremnici.xml");
                string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Izmjenjena količina benzina u spremniku!");
                iLogovi.Close();
                Console.WriteLine("Uspješno ste izvršili izmjenu dostupne količine goriva u spremniku ! ");
            }
            else
            {
                Console.WriteLine("Unesli ste količinu goriva koja je manja od 1000 litara, ili premašuje maximalan kapacitet spremnika koji iznosi 20000 litara ! ");
            }
            NakonAkcije();
        }
        public static void StatistikaProdanogGoriva()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za odabir na koji način
             * želimo pregledati statitiku prodanog
             * goriva
             * 
             * --------------------------------------------
             */
            double a;
            Console.WriteLine("========================================================");
            Console.WriteLine("Odaberite željeni izbornik :                           =");
            Console.WriteLine("1. UKUPNA KOLIČINA PRODANOG DIZELA                     =");
            Console.WriteLine("2. UKUPNA KOLIČINA PRODANOG BENZINA                    =");
            Console.WriteLine("3. ZAPOSLENICI SORTIRANI PREMA KOLIČINI PRODANOG GORIVA=");
            Console.WriteLine("========================================================");
            Console.Write("Vaš odabir : ");
            a = Convert.ToDouble(Console.ReadLine());
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            switch (a)
            {
                case 1:
                    StreamWriter iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku UKUPNA KOLIČINA PRODANOG DIZELA");
                    iLogovi.Close();
                    UkupnaKolicinaProdanogDizela();
                    break;
                case 2:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku UKUPNA KOLIČINA PRODANOG BENZINA");
                    iLogovi.Close();
                    UkupnaKolicinaProdanogBenzina();
                    break;
                case 3:
                    iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pristup izborniku ZAPOSLENICI SORTIRANI PREMA KOLIČINI PRODANOG GORIVA");
                    iLogovi.Close();
                    SortiraniZaposlenici();
                    break;
                default:
                    StatistikaProdanogGoriva();
                    break;
            }
        }
        public static void UkupnaKolicinaProdanogDizela()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za odabir za pregled
             * ukupne statistike prodanog dizela
             * 
             * 
             * --------------------------------------------
             */
            double c = 0; ;
            List<Racun> lIsta = new List<Racun>();
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XmlNodeList xList = oXml.SelectNodes("/Racuni/Racun");
            foreach (XmlNode oNode in xList)
            {
                string dk1 = oNode["datumkreiranja"].InnerText;
                string ng1 = oNode["nazivgoriva"].InnerText;
                double kg1 = Convert.ToDouble(oNode["kolicinagoriva"].InnerText);
                double cg1 = Convert.ToDouble(oNode["cijenagoriva"].InnerText);
                double z1 = Convert.ToDouble(oNode["idzaposlenika"].InnerText);
                lIsta.Add(new Racun(dk1, ng1, kg1, cg1, z1));
            }
            for (int i = 0; i < lIsta.Count; i++)
            {
                if (lIsta[i].nazivgoriva == "dizel")
                {
                    c = c + lIsta[i].kolicinagoriva;
                }
            }
            Console.WriteLine("Ukupno je prodano {0} litara dizela", c);
            NakonAkcije();
        }
        public static void UkupnaKolicinaProdanogBenzina()
        {
            /*
             * --------------------------------------------
             * Funkcija služi za odabir za pregled
             * ukupne statistike prodanog dizela
             * 
             * 
             * --------------------------------------------
             */
            List<Racun> lIsta = new List<Racun>();
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XmlNodeList xList = oXml.SelectNodes("/Racuni/Racun");
            double c = 0; ;
            foreach (XmlNode oNode in xList)
            {
                string dk1 = oNode["datumkreiranja"].InnerText;
                string ng1 = oNode["nazivgoriva"].InnerText;
                double kg1 = Convert.ToDouble(oNode["kolicinagoriva"].InnerText);
                double cg1 = Convert.ToDouble(oNode["cijenagoriva"].InnerText);
                double z1 = Convert.ToDouble(oNode["idzaposlenika"].InnerText);
                lIsta.Add(new Racun(dk1, ng1, kg1, cg1, z1));
            }
            for (int i = 0; i < lIsta.Count; i++)
            {
                if (lIsta[i].nazivgoriva == "benzin")
                {
                    c = c + lIsta[i].kolicinagoriva;
                }
            }
            Console.WriteLine("Ukupno je prodano {0} litara benzina", c);
            NakonAkcije();
        }
        public static void SortiraniZaposlenici()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija  služi za ispis sortiranih zaposlenika
             * po količini prodanog goriva
             * 
             * 
             * --------------------------------------------
             */
            Console.Clear();
            double c = 0;
            List<KolicinaGoriva> kOlicinagoriva = new List<KolicinaGoriva>();
            List<Login> lLogin = new List<Login>();
            XmlDocument rXml = new XmlDocument();
            rXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\config.xml");
            XmlNodeList rList = rXml.SelectNodes("/config/korisnickiracun");
            foreach (XmlNode oNode in rList)
            {
                double ID = Convert.ToDouble(oNode["id"].InnerText);
                string us = oNode["username"].InnerText;
                string pw = oNode["password"].InnerText;
                lLogin.Add(new Login(ID, us, pw));
            }
            List<Racun> lIsta = new List<Racun>();
            XmlDocument oXml = new XmlDocument();
            oXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\racuni.xml");
            XmlNodeList xList = oXml.SelectNodes("/Racuni/Racun");
            foreach (XmlNode oNode in xList)
            {
                string dk1 = oNode["datumkreiranja"].InnerText;
                string ng1 = oNode["nazivgoriva"].InnerText;
                double kg1 = Convert.ToDouble(oNode["kolicinagoriva"].InnerText);
                double cg1 = Convert.ToDouble(oNode["cijenagoriva"].InnerText);
                double z1 = Convert.ToDouble(oNode["idzaposlenika"].InnerText);
                lIsta.Add(new Racun(dk1, ng1, kg1, cg1, z1));
            }
            for (int i = 0; i < lLogin.Count; i++)
            {
                string IZ = lLogin[i].username;
                for (int j = 0; j < lIsta.Count; j++)
                {
                    if (lLogin[i].id == lIsta[j].idzaposlenika)
                    {
                        c = c + lIsta[j].kolicinagoriva;
                    }
                }
                double PG = c;
                kOlicinagoriva.Add(new KolicinaGoriva(IZ, PG));
                c = 0;
            }
            kOlicinagoriva = kOlicinagoriva.OrderBy(x => x.ProdanoGorivo).ToList();
            for (int i = 0; i < kOlicinagoriva.Count; i++)
            {
                for (i = 0; i < kOlicinagoriva.Count; i++)
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine("Ime zaposlenika : {0} ", kOlicinagoriva[i].ImeZaposlenika);
                    Console.WriteLine("Kolicina prodanog goriva : {0} ", kOlicinagoriva[i].ProdanoGorivo);
                }
            }
            NakonAkcije();
        }
        public static void NakonAkcije()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija služi za poziv glavnog izbornika
             * ili za izlaz iz programa.
             * 
             * 
             * --------------------------------------------
             */
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pritisnite tipku enter za povratak u glavni izbornik, ili tipku ESC za izlaz iz programa!");
            var info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape)
            {
                string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Izlazak iz programa!");
                iLogovi.Close();
                return;
            }
            if (info.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                GlavniIzbornik();
            }
        }
        public static void Logovi()
        {
            /*
             * --------------------------------------------
             * Funkcija zapisuje tekst u logove o uspješnom
             * pokretanju programa
             * 
             * 
             * --------------------------------------------
             */
            string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
            StreamWriter iLogovi = new StreamWriter(put, true);
            iLogovi.WriteLine(DateTime.Now.ToString() + " -  Pokretanje programa");
            iLogovi.Close();
        }
        public static void Prijava()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija prijavljuje korisnika u program
             * 
             * 
             * --------------------------------------------
             */
            string username, password;
            Console.Write("Unesite vaše korisničko ime : ");
            username = Convert.ToString(Console.ReadLine());
            Console.Write("Unesite vašu lozinku : ");
            password = Convert.ToString(Console.ReadLine());
            List<Login> lLogin = new List<Login>();
            XmlDocument rXml = new XmlDocument();
            rXml.Load(@"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\config.xml");
            XmlNodeList xList = rXml.SelectNodes("/config/korisnickiracun");
            foreach (XmlNode oNode in xList)
            {
                double ID = Convert.ToDouble(oNode["id"].InnerText);
                string us = oNode["username"].InnerText;
                string pw = oNode["password"].InnerText;
                lLogin.Add(new Login(ID, us, pw));
            }
            for (int i = 0; i < lLogin.Count; i++)
            {
                if (lLogin[i].username == username && lLogin[i].password == password)
                {
                    string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                    StreamWriter iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Korisnik {0} se uspješno prijavio!", username);
                    iLogovi.Close();
                    string putr = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\pomocnitxt.txt";
                    StreamWriter iPomocni = new StreamWriter(putr, false);
                    iPomocni.Flush();
                    iPomocni.WriteLine(lLogin[i].id);
                    iPomocni.Close();
                    Console.Clear();
                    GlavniIzbornik();
                    return;
                }
            }
            for (int i = 0; i < lLogin.Count; i++)
            {
                if (lLogin[i].username != username || lLogin[i].password != password)
                {
                    string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                    StreamWriter iLogovi = new StreamWriter(put, true);
                    iLogovi.WriteLine(DateTime.Now.ToString() + " -  Neuspješni pokušaj prijave!");
                    iLogovi.Close();
                    Console.Clear();
                    Console.WriteLine("Neuspješni pokušaj prijave, pokušajte ponovno!");
                    Prijava();
                }
            }
        }
        public static void NakonOdjave()
        {
            /*
             * --------------------------------------------
             * 
             * Funkcija služi za poziv ponovne prijave
             * ili za izlaz iz programa nakon odjave.
             * 
             * 
             * --------------------------------------------
             */
            Console.WriteLine("Pritisnite tipku enter za ponovnu prijavu, ili tipku ESC za izlaz iz programa!");
            var info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Prijava();
            }
            if (info.Key == ConsoleKey.Escape)
            {
                string put = @"C:\Users\NS\Desktop\Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\Konstrukcijske vjezbe - Benzinska crpka\\Logovi.txt";
                StreamWriter iLogovi = new StreamWriter(put, true);
                iLogovi.WriteLine(DateTime.Now.ToString() + " -  Izlazak iz programa!");
                iLogovi.Close();
                return;
            }
        }
        static void Main(string[] args)
        {
            Logovi();
            Prijava();
        }
    }
}