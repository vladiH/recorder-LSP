using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApplication1
{
    class CArchivo
    {
        String rutanueva = "";
        public void CrearArchivo(String pNombre)
        {
            pNombre = rutanueva + pNombre;
            //verificar la existencia del archivo antes de crear
            if (!File.Exists(pNombre))
            {
                //crear el  archivo fisico
                StreamWriter writer =File.CreateText(pNombre);
                //escribir una linea dentro del archivo
                //cerrar el archivo
                writer.Close();
            }
        }
        public void setNewPath(String path){
            rutanueva = path;
            if (rutanueva == "Default")
            {
                rutanueva = "";
            }
            else {
                    String ultimochar = path.Substring(path.Length - 1);
                    if (ultimochar != "/")
                    {
                        rutanueva = path + "/";
                    }
               
            }
        }
        public void Leerarchivo(String pNombre)
        {
            pNombre = rutanueva + pNombre;
            if (File.Exists(pNombre))
            {
                //asignar el archivo fisico  a la variable   de lectura
                StreamReader FLectura = new StreamReader(pNombre);
                //leer la primera linea del archivo
                string sLinea;
                sLinea = FLectura.ReadLine();
                //escribir todas las lineas del archivo
                while (sLinea != null)
                {
                    Console.WriteLine(sLinea);
                    sLinea = FLectura.ReadLine();
                }
                FLectura.Close();
            }
        }
        public void EscribirArchivo(String pNombre, String pDato)
        {
            pNombre = rutanueva + pNombre;
            if (File.Exists(pNombre))
            {
                //asignar el archivo a la variable escritura
                StreamWriter FEscritura = new StreamWriter(pNombre, true);
                FEscritura.Write(pDato);
                FEscritura.Close();
            }
        }
        public void EscribirNewline(String pNombre)
        {
            pNombre = rutanueva + pNombre;
            if (File.Exists(pNombre))
            {
                //asignar el archivo a la variable escritura
                StreamWriter FEscritura = new StreamWriter(pNombre, true);
                FEscritura.WriteLine();
                FEscritura.Close();
            }
        }
        public void CrearDirectorio(string pDireccion)
        {
            pDireccion = rutanueva + pDireccion;
            //verificar que el directorio esista
            if (Directory.Exists(pDireccion))
            {
                Console.WriteLine("el directorio ya existe");
                return;
            }
            //crear directorio
            DirectoryInfo direc = Directory.CreateDirectory(pDireccion);
            Console.WriteLine("el directorio se creo {0}", Directory.GetCreationTime(pDireccion));
        }
        public void crearXML(String width, String height, int img, String result, String archivo)
        {
            archivo = rutanueva + archivo;
            XDocument doc = new XDocument(new XElement("lsp_storage",
                                              new XElement("depthImg" + img,
                                                  new XElement("width", width),
                                                  new XElement("height", height),
                                                  new XElement("origin", "top-left"),
                                                  new XElement("layout", "interleaved"),
                                                  new XElement("dt", "w"),
                                                  new XElement("data", result))));
            doc.Save(archivo + img + ".xml");
        }
        public String [] leerXML(String ruta)
        {
            ruta = rutanueva + ruta;
            String[] datos = new String[3];
            XDocument data = XDocument.Load(ruta+".xml");
            var depth = from c in data.Elements("lsp_storage").Elements(ruta)
                        select c.Element("data").Value;
            var width = from c in data.Elements("lsp_storage").Elements(ruta)
                        select c.Element("width").Value;
            var height = from c in data.Elements("lsp_storage").Elements(ruta)
                         select c.Element("height").Value;
            datos[0] = depth.ElementAt(0);
            datos[1] = width.ElementAt(0);
            datos[2] = height.ElementAt(0);
            return datos;
        }//Fin de metdo leerXML.
    }
}
