using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCIOS
{
    class contiene
    {
        public bool Contiene(string palabra, string cadena)
        {
            for (int i = 0; i <= palabra.Length - cadena.Length; i++)
                //Si encontramos dos letras iguales
                if (palabra[i] == cadena[0])
                {
                    bool contenida = true;
                    //Recorremos la cadena desde la posición 1
                    //y comparamos con la palabra a partir de 
                    //la posición donde las dos letras iguales
                    for (int j = 1; j < cadena.Length; j++)
                        if (palabra[i + j] != cadena[j])
                            contenida = false;
                    //Si esta contenida
                    if (contenida)
                        return true;
                }
            //Si no está contenida
            return false;
        }
    }
}
