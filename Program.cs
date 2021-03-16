using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcsTestExcel.Model;

namespace TcsTestExcel
{
    class Program
    {
        static void Main(string[] args)
        {


            List<String> MisTitulos = new List<string>();
            HtmlWeb cWeb = new HtmlWeb();

            using (PruebaTestingEntities1 db = new PruebaTestingEntities1())
            {
                

                for (int i = 1; i <= 32; i++)
                {
                    string url = "http://hdeleon.net/";

                    if (i > 1) url += "/page" + i + "/";


                    HtmlDocument doc = cWeb.Load(url);
                    foreach (var Nodo in doc.DocumentNode.CssSelect(".entry-title"))
                    {
                        var NodoAncho = Nodo.CssSelect("a").First();
                        var oTitles = new titles();
                        oTitles.title = NodoAncho.InnerHtml;

                        db.titles.Add(oTitles);



                        MisTitulos.Add(NodoAncho.InnerHtml);

                    }

                    Console.WriteLine("Se han visitado: " + i + " paginas");
                }
              
                db.SaveChanges();
            }
            
        }
    }
}

 