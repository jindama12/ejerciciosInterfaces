using ra4_actividades.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ra4_actividades.Controlador
{
    public partial class ControladorUsuario
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();

        public static void cargarUsuarios()
        {
            try
            {
                string xml = File.ReadAllText("usuarios.xml");
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new
                    XmlSerializer(listaUsuarios.GetType());
                    listaUsuarios = (List<Usuario>)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error leyendo xml " + e.Message);
            }
        }

        public static void addUser(Usuario u)
        {
            listaUsuarios.Add((Usuario)u);
        }

        public static void guardarUsuarioXML()
        {
            try
            {
                using (var writer = new StreamWriter("usuarios.xml"))
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    var serializer = new XmlSerializer(listaUsuarios.GetType());
                    serializer.Serialize(writer, listaUsuarios, namespaces);
                }
            } catch (Exception e) {}
        }

        public static void leerUsuarioXML()
        {
            try
            {
                string xml = File.ReadAllText("usuarios.xml");
                using (var reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new
                    XmlSerializer(listaUsuarios.GetType());
                    listaUsuarios = (List<Usuario>)serializer.Deserialize(reader);
                }
            }
            catch (Exception e) {}
        }

        public static void guardarUsuarioJSON()
        {
            try
            {
                if (File.Exists("usuarios.json"))
                {
                    string jsonString = JsonSerializer.Serialize(listaUsuarios);
                    File.WriteAllText("usuarios.json", jsonString);
                }
            }
            catch (Exception e) {}
        }

        public static void leerUsuarioJSON()
        {
            try
            {
                if (File.Exists("ventas.json"))
                {
                    string jsonString = File.ReadAllText("ventas.json");
                    listaUsuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonString);
                }
            }
            catch (Exception e) {}
        }

        public static void guardarUsuarioBin()
        {
            try
            {
                Stream SaveFileStream = File.Create("usuarios.bin");
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(SaveFileStream, listaUsuarios);
                SaveFileStream.Close();
            }
            catch (Exception e) {}
        }

        public static void leerUsuarioBin()
        {
            try
            {
                Stream OpenFileStream = File.OpenRead("usuarios.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                listaUsuarios = (List<Usuario>)deserializer.Deserialize(OpenFileStream);
                OpenFileStream.Close();
            }
            catch (Exception e) {}
        }
    }
}
