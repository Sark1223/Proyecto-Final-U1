using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //Generar Botones principales
        //Iniciar timer
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
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.WhiteSmoke,
                    BackColor= Color.Black,
                    Size = new Size(40, 40),
                    Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    Location = new Point(ale.Next(0, (this.ClientSize.Width - 40)), ale.Next(0, (this.ClientSize.Height - 40)))
                };
                pares.FlatAppearance.BorderSize = 0;
                pares.FlatStyle = FlatStyle.Flat;
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

        Random ale = new Random();

        //Arreglo de direcciones
        string[] direccion = { "derecha", "izquierda", "abajo", "arriba" };

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
                //LLaamada al metodo para mover los botones
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

        }

        bool impacto = false;
        //Choque de botones
        public void Choque(/*Control pares, Control impares*/)
        {
            for (int x = 0; x < principalesPares.Count; x++)
            {
                for (int y = 0; y < principalesImpares.Count; y++)
                {
                    if (principalesPares[x].Bounds.IntersectsWith(principalesImpares[y].Bounds) && impacto == false)
                    {
                        lbl.Text = "par impar";

                        int a = (int)pares.Tag;
                        int b = (int)impares.Tag;
                        generarBotones("pares", (a + b));
                        impacto= true;
                        RepelerPares(principalesPares[x].Name, x);
                        RepelerImpares(principalesImpares[y].Name, y);
                    }
                    
                }
                impacto = false;
            }

            //if (pares.Bounds.IntersectsWith(pares.Bounds))
            //{
            //    int a = (int)pares.Tag;
            //    int b = (int)pares.Tag;
            //    lbl.Text = "pares";
            //    lbl.Visible = true;
            //    generarBotones("pares", (a + b));

            //}
            //if (impares.Bounds.IntersectsWith(impares.Bounds))
            //{
            //    lbl.Text = "impares";
            //    int a = (int)impares.Tag;
            //    int b = (int)impares.Tag;
            //    generarBotones("impares", (a + b));
            //}
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

        public void generarBotones(string tipo, int cantidad)
        {
            if (tipo == "pares")
            {
                for (int p = 0; p < 1/*cantidad*/; p++)
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
            else if (tipo == "impares")
            {
                for (int i = 0; i < 1; i++)
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
    }
}
