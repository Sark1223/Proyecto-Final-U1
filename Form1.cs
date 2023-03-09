using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//trabajo simultaneo

namespace Proyecto_Final_U1
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        //Elemento Botones Pares
        Button pares;

        //Lista Botones Pares
        List<Button> principalesPares = new List<Button>();

        //Elemento Botones Impares
        Button impares;

        //Lista Botones Impares
        List<Button> principalesImpares = new List<Button>();

        //Generador de numeros aleatorios
        Random ale = new Random();

        //Arreglo de direcciones
        string[] direccion = { "derecha", "izquierda", "abajo", "arriba" };

        bool impacto = false;

        /*Generar Botones principales
         Agrega los botones a principales las listas pares e impares
        para poder borrarlos al momento de cumplirse ciertas condiciones
        Agrega todas las caracteristicas a los botes
        Despliega botones y manda a llamar al metodo
        movimientos para comenzar*/
        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            //Generar botones PARES principales
            for(int p =0; p < 2; p++)
            {
                int valorPar = (ale.Next(1, 6) * 2);

                //Diseño de los botones
                pares = new Button
                {
                    //Asignar direccion
                    Name = "" + direccion[ale.Next(4)],
                    //generar indice aleatorio par
                    Text = "" + valorPar,
                    //alineamiento de texto
                    TextAlign = ContentAlignment.MiddleCenter,
                    //color de fuente
                    ForeColor = Color.WhiteSmoke,
                    //color de boton
                    BackColor= Color.Black,
                    //tamaño de boton
                    Size = new Size(40, 40),
                    //tipo de fuente
                    Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    //localizacion de boton
                    Location = new Point(ale.Next(0, (this.ClientSize.Width - 40)), ale.Next(0, (this.ClientSize.Height - 40)))
                };
                //apariencia de borde
                pares.FlatAppearance.BorderSize = 0;
                pares.FlatStyle = FlatStyle.Flat;
                //asignacion de un valor a propiedad Tag
                pares.Tag = valorPar;
                pares.ClientSize = new Size(40, 40);

                //Agregar botones valorPar la lista
                principalesPares.Add(pares);

                //Agregar botones valorPar la forma
                this.Controls.Add(pares);
            }

            //Generar botones IMPARES principales
            for (int i = 0; i < 2; i++)
            {
                int valorImpar = ((ale.Next(1, 6) * 2) - 1); 
                //Diseño de los botones
                impares = new Button
                {
                    //Asignar direccion
                    Name = "" + direccion[ale.Next(4)],
                    //generar indice aleatorio par
                    Text = "" + valorImpar,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.WhiteSmoke,
                    BackColor = Color.DarkMagenta,
                    Size = new Size(40, 40),
                    Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(ale.Next(0, (this.ClientSize.Width - 40)), ale.Next(0, (this.ClientSize.Height - 40)))
                };
                impares.FlatAppearance.BorderSize = 0;
                impares.FlatStyle = FlatStyle.Flat;
                impares.Tag = valorImpar;
                impares.ClientSize = new Size(40, 40);

                //Agregar botones valorPar la lista
                principalesImpares.Add(impares);

                //Agregar botones valorPar la forma
                this.Controls.Add(impares);
            }

            ttMovimiento.Start();

        }

        //Movimiento de botones generados 
        public void MovBtns(Control name, string op)
        {
            if (op == "derecha")
            {
                if (name.Location.X < (ClientSize.Width - 40) && name.Location.Y < (this.ClientSize.Height - 40))
                {
                    name.Location = new Point(name.Location.X + 2, name.Location.Y + 2);

                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }
            else if (op == "izquierda")
            {
                if (name.Location.X > -2 && name.Location.Y > -2)
                {
                    name.Location = new Point(name.Location.X - 2, name.Location.Y - 2);
                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }
            else if (op == "abajo")
            {
                if (name.Location.X > -2 && name.Location.Y < (this.ClientSize.Height - 40))
                {
                    name.Location = new Point(name.Location.X - 2, name.Location.Y + 2);

                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }
            else if (op == "arriba")
            {
                if (name.Location.X < (this.ClientSize.Width - 40) && name.Location.Y > -2)
                {
                    name.Location = new Point(name.Location.X + 2, name.Location.Y - 2);
                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }
            else if (op == "horizontal")
            {
                if (name.Location.X < (this.ClientSize.Width - 40) && name.Location.Y > -2)
                {
                    name.Location = new Point(name.Location.X + 2, name.Location.Y);
                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }
            else
            {
                if (name.Location.X > -2 && name.Location.Y < (this.ClientSize.Height - 40))
                {
                    name.Location = new Point(name.Location.X, name.Location.Y + 2);

                }
                else
                {
                    name.Name = direccion[ale.Next(4)];
                }
            }

        }

        //Timer para el movimiento
        private void ttMovimiento_Tick(object sender, EventArgs e)
        {
            //buscar los botones en la lista 
            foreach (Button pares in principalesPares)
            {
                //LLamada al metodo para mover los botones
                MovBtns(pares, pares.Name);//boton actual, la direccion del boton actual
                                           //    lbl.Text = lbl.Text + "" + pares.Name + "  " + pares.Text + "   " + pares.Tag + "\n";
            }
            //buscar los botones en la lista 
            foreach (Button impares in principalesImpares)
            {
                //LLaamada al metodo para mover los botones
                MovBtns(impares, impares.Name);//boton actual, la direccion del boton actual

            }

            //foreach (Button pares in principalesPares)
            //{
            //    foreach (Button impares in principalesImpares)
            //    {
            Choque(/*pares, impares*/);
            //    }
            //}
            //ReiniciarForma();
            CambiarColor();
        }
        public void CambiarColor()
        {
            if ((principalesPares.Count + principalesImpares.Count) > 50)
            {
                BackColor = Color.Red;
            }
            else
            {
                BackColor = Color.Teal;
            }
        }
        public void ReiniciarForma()
        {
            if (principalesImpares.Count == 0)
            {
                MessageBox.Show("YA NO HAY BOTONEES IMPARES");
                Application.Restart();
            }
            else if (principalesPares.Count ==0)
            {
                MessageBox.Show("YA NO HAY BOTONES PARES");
                Application.Restart();
            }

        }
        ////Choque de botones
        //public void Choque(/*Control pares, Control impares*/)
        //{
        //    int pa = principalesPares.Count-1;
        //    //Ciclo for para recorrer todos nuestro BOTONES PARES
        //    for (int x = 0; x < pa; x++)
        //    {
        //        //si x esta en el penultimo boton par 
        //        if( x < principalesPares.Count - 2 || (principalesPares.Count == 2 && x == 0))
        //        {
        //            //comparra si esta chocando la el boton par actual con el predecesor
        //            if (principalesPares[x].Bounds.IntersectsWith(principalesPares[x + 1].Bounds) && impacto == false || principalesPares[x + 1].Bounds.IntersectsWith(principalesPares[x].Bounds))
        //            {
        //                lbl.Text = "par con par";

        //                int a = (int)principalesPares[x].Tag;
        //                int b = (int)principalesPares[x + 1].Tag;
        //                GenerarBotones("pares", (a + b));
        //                //impacto = true;
        //                RepelerPares(principalesPares[x].Name, x /*boton actual*/);
        //                RepelerPares(principalesPares[x + 1].Name, x + 1 /*boton actual*/);
        //            }

        //            //impacto = true;
        //        }

        //        //Ciclo for para recorrer todos nuestro BOTONES IMPARES
        //        int impa = principalesImpares.Count-1;
        //        for (int y = 0; y < impa; y++)
        //        {
        //            //si y esta en el penultimo boton impar 
        //            if (y < principalesImpares.Count - 2 || (principalesImpares.Count == 2 && y ==0))
        //            {
        //                //comparra si esta chocando la el boton impar actual con el predecesor
        //                if (principalesImpares[y].Bounds.IntersectsWith(principalesImpares[y + 1].Bounds) && impacto == false || principalesImpares[y + 1].Bounds.IntersectsWith(principalesImpares[y].Bounds))
        //                {
        //                    lbl.Text = "impar con impar";

        //                    int a = (int)principalesPares[y].Tag;
        //                    int b = (int)principalesPares[y + 1].Tag;
        //                    GenerarBotones("impares", (a + b));
        //                    //impacto = true;
        //                    RepelerImpares(principalesImpares[y].Name, y /*boton actual*/);
        //                    RepelerImpares(principalesImpares[y + 1].Name, y + 1/*boton actual*/);
        //                }
        //                //impacto = false;
        //            }

        //            //comprobar si un par esta chocando con un impar
        //            if (principalesPares[x].Bounds.IntersectsWith(principalesImpares[y].Bounds) && impacto == false)
        //            {

        //                lbl.Text = "par impar";

        //                int valorPar = (int)principalesPares[x].Tag;
        //                int valorImpar = (int)principalesImpares[y].Tag;

        //                if (valorPar > valorImpar)
        //                {
        //                    //remueve el boton impar que choco con el boton par con mayor indice
        //                    //principalesImpares.Remove(principalesImpares[y]);

        //                    //eliminara tantos botones impares como su indice indica
        //                    EliminarBotones("impares", valorPar);
        //                }
        //                else
        //                {
        //                    //remueve el boton par con que choco con el boton impar con mayor indice
        //                    //principalesPares.Remove(principalesPares[x]);
        //                    EliminarBotones("pares",valorImpar);
        //                }
        //            }

        //        }//fin ciclo for impares

        //    }//fin ciclo for pares

        //}

        //metodo para hacer rebotar los botones entre ellos

        //Choque de botones
        public void Choque(/*Control pares, Control impares*/)
        {
            int pa = principalesPares.Count;
            //Ciclo for para recorrer todos nuestro BOTONES PARES
            for (int x = 0; x < pa; x++)
            {
                //si x esta en el penultimo boton par 
                if (x < pa - 2 || (pa == 2 && x == 0))
                {
                    //comparra si esta chocando la el boton par actual con el predecesor
                    if (principalesPares[x].Bounds.IntersectsWith(principalesPares[x + 1].Bounds) && impacto == false || principalesPares[x + 1].Bounds.IntersectsWith(principalesPares[x].Bounds))
                    {
                        lbl.Text = "par con par";

                        int a = (int)principalesPares[x].Tag;
                        int b = (int)principalesPares[x + 1].Tag;
                        GenerarBotones("pares", (a + b));
                        //impacto = true;
                        RepelerPares(principalesPares[x].Name, x /*boton actual*/);
                        RepelerPares(principalesPares[x + 1].Name, x + 1 /*boton actual*/);
                    }

                    //impacto = true;
                }

                //Ciclo for para recorrer todos nuestro BOTONES IMPARES
                int impa = principalesImpares.Count;
                for (int y = 0; y < impa; y++)
                {
                    //si y esta en el penultimo boton impar 
                    if (y < impa - 2 || (impa == 2 && y == 0))
                    {
                        //comparra si esta chocando la el boton impar actual con el predecesor
                        if (principalesImpares[y].Bounds.IntersectsWith(principalesImpares[y + 1].Bounds) && impacto == false || principalesImpares[y + 1].Bounds.IntersectsWith(principalesImpares[y].Bounds))
                        {
                            lbl.Text = "impar con impar";

                            int a = (int)principalesImpares[y].Tag;
                            int b = (int)principalesImpares[y + 1].Tag;
                            GenerarBotones("impares", (a + b));
                            //impacto = true;
                            RepelerImpares(principalesImpares[y].Name, y /*boton actual*/);
                            RepelerImpares(principalesImpares[y + 1].Name, y + 1/*boton actual*/);
                        }
                        //impacto = false;
                    }

                    if(principalesPares.Count > 0 && principalesImpares.Count > 0)
                    {
                        //comprobar si un par esta chocando con un impar
                        if (principalesPares[x].Bounds.IntersectsWith(principalesImpares[y].Bounds) && impacto == false)
                        {

                            lbl.Text = "par impar";

                            int valorPar = (int)principalesPares[x].Tag;
                            int valorImpar = (int)principalesImpares[y].Tag;

                            if (valorPar > valorImpar)
                            {
                                //remueve el boton impar que choco con el boton par con mayor indice
                                this.Controls.Remove(principalesImpares[y]);
                                principalesImpares.RemoveAt(y);

                                //eliminara tantos botones impares como su indice indica
                                EliminarBotones("impares", valorPar);
                            }
                            else
                            {
                                //remueve el boton par con que choco con el boton impar con mayor indice
                                this.Controls.Remove(principalesPares[x]);
                                principalesPares.RemoveAt(x);
                                EliminarBotones("pares", valorImpar);
                            }
                        }
                    }
                   

                }//fin ciclo for impares

            }//fin ciclo for pares

        }

        public void RepelerPares(string dire, int actual)
        {
            string cambio = direccion[ale.Next(4)];

            if (cambio != dire)
            {
                principalesPares[actual].Name = cambio;
            }
            else
            {
                RepelerPares(dire, actual);
            }
        }

        //metodo para hacer rebotar los botones entre ellos
        public void RepelerImpares(string dire, int actual)
        {
            string cambio = direccion[ale.Next(4)];

            if (cambio != dire)
            {
                principalesImpares[actual].Name = cambio;
            }
            else
            {
                RepelerImpares(dire, actual);
            }
        }

        //Metodo para generar botones en caso de que choquen 
        public void GenerarBotones(string tipo, int cantidad)
        {
            if (tipo == "pares")
            {
                for (int p = 0; p < cantidad; p++)
                {
                    int valorPar = ale.Next(1, 6) * 2;
                    //Diseño de los botones
                    pares = new Button
                    {
                        //Asignar direccion
                        Name = "" + direccion[ale.Next(4)],
                        //generar indice aleatorio par
                        Text = "" + valorPar,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.WhiteSmoke,
                        BackColor = Color.YellowGreen,
                        Size = new Size(40, 40),
                        Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                        Location = new Point(ale.Next(0, (this.ClientSize.Width - 40)), ale.Next(0, (this.ClientSize.Height - 40)))
                    };
                    pares.FlatAppearance.BorderSize = 0;
                    pares.FlatStyle = FlatStyle.Flat;
                    pares.Tag = valorPar;

                    //Agregar botones valorPar la lista
                    principalesPares.Add(pares);

                    //Agregar botones valorPar la forma
                    this.Controls.Add(pares);
                }
            }
            
            if (tipo == "impares")
            {
                for (int i = 0; i < cantidad; i++)
                {
                    int valorImpar = (ale.Next(1, 6) * 2)-1;

                    //Diseño de los botones
                    impares = new Button
                    {
                        //Asignar direccion
                        Name = "" + direccion[ale.Next(4)],
                        //generar indice aleatorio par
                        Text = "" + valorImpar,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.WhiteSmoke,
                        BackColor = Color.HotPink,
                        Size = new Size(40, 40),
                        Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                        Location = new Point(ale.Next(0, (this.ClientSize.Width - 40)), ale.Next(0, (this.ClientSize.Height - 40)))
                    };
                    impares.FlatAppearance.BorderSize = 0;
                    impares.FlatStyle = FlatStyle.Flat;
                    impares.Tag = valorImpar;

                    //Agregar botones valorPar la lista
                    principalesImpares.Add(impares);

                    //Agregar botones valorPar la forma
                    this.Controls.Add(impares);
                }
            }
        }

        //Metodo para eliminar botones, recibe como paramentro el tipo de botones a eliminar
        public void EliminarBotones(string tipo, int cantidad)
        {
            if (tipo == "pares")
            {
                if(principalesPares.Count > cantidad)
                {
                    for (int p = 0; p < cantidad; p++)
                    {
                        //Eliminar botones valorPar la lista
                        //principalesPares.Remove(pares/*pares*/);
                        //Elige un valor aleatorio para eliminar
                        int eliPar = ale.Next(principalesPares.Count);

                        lbl.Text = "soy yo";

                        //Primero elimina el boton de la forma
                        this.Controls.Remove(principalesPares[eliPar]);
                        //luego lo borra de la lista
                        principalesPares.RemoveAt(eliPar);
                    }
                }
                else
                {
                    int cantidadDisponible = principalesPares.Count;

                    for (int p = 0; p < cantidadDisponible; p++)
                    {
                        //Elige un valor aleatorio para eliminar
                        int eliPar = ale.Next(principalesPares.Count);


                        //Agregar botones valorPar la forma
                        this.Controls.Remove(principalesPares[eliPar]);
                        
                        //Eliminar botones valorPar la lista
                        principalesPares.RemoveAt(eliPar);
                    }
                    ReiniciarForma();
                }
               
            }
            else if (tipo == "impares")
            {
                if(principalesImpares.Count > cantidad)
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        ////Eliminar botones valorImpar la lista
                        //principalesImpares.Remove(impares);
                        //principalesImpares.RemoveAt(ale.Next(principalesImpares.Count));

                        ////Eliminar botones valorImpar la forma
                        //this.Controls.Remove(impares);

                        int eliImpar = ale.Next(principalesImpares.Count);

                        //Primero elimina el boton de la forma
                        this.Controls.Remove(principalesImpares[eliImpar]);
                        //luego lo borra de la lista
                        principalesImpares.RemoveAt(eliImpar);
                    }
                }
                else
                {
                    int cantidadDisponible = principalesImpares.Count;

                    for (int p = 0; p < cantidadDisponible; p++)
                    {
                        ////Eliminar botones valorPar la lista
                        //principalesImpares.Remove(impares);

                        ////Agregar botones valorPar la forma
                        //this.Controls.Remove(impares);

                        int eliImpar = ale.Next(principalesImpares.Count);

                        //Primero elimina el boton de la forma
                        this.Controls.Remove(principalesImpares[eliImpar]);
                        //luego lo borra de la lista
                        principalesImpares.RemoveAt(eliImpar);


                    }
                    ReiniciarForma();
                }

            }
        }
    }
}
//CHOQUE

//for (int x = 0; x < principalesPares.Count; x++)
//{
//    for (int y = 0; y < principalesImpares.Count; y++)
//    {
//        if (principalesPares[x].Bounds.IntersectsWith(principalesImpares[y].Bounds) && impacto == false)
//        {
//            lbl.Text = "par impar";

//            int a = (int)pares.Tag;
//            int b = (int)impares.Tag;
//            GenerarBotones("pares", (a + b));
//            impacto = true;
//            RepelerPares(principalesPares[x].Name, x);
//            RepelerImpares(principalesImpares[y].Name, y);
//        }
//    }
//    impacto = false;
//}



//for (int x = 0; x < principalesPares.Count; x++)
//{
//    for (int y = 0; y < principalesImpares.Count; y++)
//    {

//    }
//    impacto = false;
//}

//for (int x = 0; x < principalesPares.Count; x++)
//{
//    if (x < principalesPares.Count - 1)
//    {
//        lbl.Text = "par con par";

//        int a = (int)pares.Tag;
//        int b = (int)pares.Tag;
//        GenerarBotones("pares", (a + b));
//        impacto = true;
//        for (int y = 0; y < principalesImpares.Count; y++)
//        {
//            if (y < principalesImpares.Count - 1)
//            {
//                lbl.Text = "par con par";

//                int c = (int)impares.Tag;
//                int d = (int)impares.Tag;
//                GenerarBotones("pares", (a + b));
//                impacto = true;
//            }
//           if(x == y)
//            {

//            }
//        }
//    }
//}

//ELIMINAR BOTONES ALEATORIAMENTE
//for (int p = 0; p < 1/*cantidad*/; p++)
//{
//    //Eliminar botones valorPar la lista
//    principalesPares.Remove(principalesPares[ale.Next(0, principalesPares.Count() + 1)]);

//    //Agregar botones valorPar la forma
//    this.Controls.Remove(pares);
//}
//for (int p = 0; p < cantidadDisponible; p++)
//{
//    //Eliminar botones valorPar la lista
//    principalesPares.Remove(principalesPares[ale.Next(0, principalesPares.Count() + 1)]);

//    //Agregar botones valorPar la forma
//    this.Controls.Remove(pares);
//}
