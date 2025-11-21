using static System.Console;

namespace es
{
    internal class Program
    {
        static string path = "mosse.txt";
        static string obbiettivo = "obbiettivo.txt";
        static List<string> cosafa;
        static List<string> mosse;
        static List<Cpg> pg;

        static void Main(string[] args)
        {
            mosse = new List<string>();
            pg = new List<Cpg>();
            cosafa = new List<string>();
            caricamosse();
            creaoggetti();
            assegnaeventi();
            eseguimosse();
            salvamosse();
        }

        static void eseguimosse()
        {
            for (int i = 0; i < mosse.Count; i++)
            {
                if (mosse[i] == "attacca re")
                {
                    for (int j = 0; j < pg.Count; j++)
                    {
                        if (pg[j] is Cre cre)
                        {
                            cre.attaccare_re();
                        }
                    }
                }
                else if (mosse[i] != "end")
                {
                    rimuovi(mosse[i]);
                }
                else
                {
                    return;
                }
            }
        }

        static void rimuovi(string nome)
        {
            string[] parti = nome.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = pg.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < parti.Length; j++)
                {
                    if (pg[i] is Cguardia cguardia && cguardia.nome == parti[j])
                    {
                        pg.RemoveAt(i);
                        break;
                    }
                    else if (pg[i] is Cpedone cpedone && cpedone.nome == parti[j])
                    {
                        pg.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        static void assegnaeventi()
        {
            for (int i = 0; i < pg.Count; i++)
            {
                if (pg[i] is Cre cre)
                {
                    cre.re_attaccato += scrivi_interazioni;
                }
            }
        }

        static void scrivi_interazioni(object sender, EventArgs e)
        {
            for (int i = 0; i < pg.Count; i++)
            {
                if (pg[i] is Cre cre)
                {
                    WriteLine(cre.ToString());
                    cosafa.Add(cre.ToString());
                }
                else if (pg[i] is Cguardia guardia)
                {
                    WriteLine(guardia.ToString());
                    cosafa.Add(guardia.ToString());
                }
                else if (pg[i] is Cpedone pedone)
                {
                    WriteLine(pedone.ToString());
                    cosafa.Add(pedone.ToString());
                }
            }
        }

        static void creaoggetti()
        {

            pg.Add(new Cre(mosse[0]));


            string[] nomiguardie = new string[100];
            nomiguardie = mosse[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for(int j = 0; j < nomiguardie.Length; j++)
            {
                if (nomiguardie[j] != null)
                {
                    pg.Add(new Cguardia(nomiguardie[j]));
                }
            }

            string[] nomipedoni = new string[100];
            nomipedoni = mosse[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < nomipedoni.Length; i++)
            {
                if (nomipedoni[i] != null)
                {
                    pg.Add(new Cpedone(nomipedoni[i]));
                }
            }

            mosse.RemoveAt(2);
            mosse.RemoveAt(1);
            mosse.RemoveAt(0);
        }

        static void caricamosse()
        {
            using (StreamReader sr = new StreamReader("mosse.txt"))
            {
                string linea;
                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine().ToLower();
                    mosse.Add(linea);
                }
            }
        }

        static void salvamosse()
        {
            using (StreamWriter sw = new StreamWriter(obbiettivo, true))
            {
                for (int i = 0; i < cosafa.Count; i++)
                {
                    sw.WriteLine(cosafa[i]);
                }
            }
        }
    }
}