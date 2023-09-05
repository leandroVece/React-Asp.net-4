// namespace Cadeteria;

// using Cadeteria.Models;
// using System.IO;
// using System;
// using System.Collections.Generic;
// using System.Configuration;
// using System.Data;
// using System.Data.SqlClient;
// using System.IO;
// using System.Linq;
// using System.Web;
// using System.Web.Mvc;

// public class fileConver
// {
//     public static List<Archivo> Conversion(List<Archivo> archivo)
//     {
//         List<Archivo> result = new List<Archivo>();

//         foreach (var item in archivo)
//         {
//             Archivo aux = new Archivo();
//             aux.Name = Path.GetFileNameWithoutExtension(item.FileName);

//         }
//         for (int i = 0; i < archivos.Length; i++)
//         {


//             archivo.Extension = Path.GetExtension(archivo[i].FileName);
//             archivo.Formato = MimeMapping.GetMimeMapping(archivos[i].FileName);

//             double tamanio = archivos[i].ContentLength;
//             tamanio = tamanio / 1000000.0;
//             archivo.Tamanio = Math.Round(tamanio, 2);

//             Stream fs = archivos[i].InputStream;
//             BinaryReader br = new BinaryReader(fs);
//             archivo.Archivo = br.ReadBytes((Int32)fs.Length);
//         }
//         return null
//     }

// }


