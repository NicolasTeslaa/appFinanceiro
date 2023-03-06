using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appFinanceiro
{
    public class appSettings
    {
        private static string DatabaseName = "database.db";

        //obtem o local onde será armazenado os dados do aplicativo, se fosse apenas uma plataforma poderiamos adicionar o caminho fixo
      // porem como são varias plataformas o caminho muda de plataforma para plataforma  
        private static string DatabaseDirectory = FileSystem.AppDataDirectory;

        //concatena os dois elementos, sendo que o caminho que deve ser configurado no MauiProgram.cs é uma junção do nome com o local onde serão armazenados os dados do cliente
        public static string DatabasePath = Path.Combine(DatabaseDirectory, DatabaseName);
    }
}
