using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            double x;
            double y;
            int ps_v;
            int a;
            int b;
            int bb;
            int ii;
            double fittest;
            string temp;
            string temper;
            double randmut;

            var arlist = new ArrayList();

            x = 0.183;
            // Задача по поиску глобального макс нижеуказанной функции относящийся к ксассу однопараметрическая функция
            y = (Math.Pow(x, 3) - (15 * Math.Pow(x, 2)) + (7 * x) + 1) / 10;
            functioninres.Content = y;

            //Получить размер изначальной популяции
            ps_v = int.Parse(ps.Text);

            // Создать изначальную популяцию
            string[] array = new string[ps_v];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i = i + 1)
            {
                double m = rand.NextDouble() * 10;

                m = Math.Round(m, 2);
                populationarray.Text = populationarray.Text + "    " + m;

                m = Math.Round(m * 256, 0);

                populationarray.Text = populationarray.Text + "    " + m + "    ";

                for (a = 0; m > 0; a++)
                {
                    populationarray.Text = populationarray.Text + m % 2;
                    array[i] = array[i] + m % 2;
                    m = Math.Floor(m / 2);
                }
                temp = array[i];
                temper = "";
                for (b = 0; b < temp.Length; b++)
                {
                    temper = temper + temp[temp.Length - 1 - b];

                }

                array[i] = temper.PadLeft(12, '0');
                temper = "";

                //result.Text = "   " + result.Text + array[i] + "  ";


                //Mix_prob_Copy5.Content = m;
                //array[i] = Convert.ToString(m, 2).PadLeft(8,'0');
                //array[i] = Convert.ToString(m, 10).PadLeft(8,'0');

                //populationarray.Text = populationarray.Text + "    " + array[i];

            }

            



            for (int unlim = 0; unlim<100; unlim=unlim+1)
            { 




            double[] arrayfitresult = new double[ps_v];
            for (ii = 0; ii < array.Length; ii = ii + 1)
            {
                fittest = (Convert.ToInt32(array[ii], 2)) / 256;

                arrayfitresult[ii] = (Math.Pow(fittest, 3) - 15 * Math.Pow(fittest, 2) + (7 * fittest) + 1) / 10;
                //resultfunction.Text = resultfunction.Text + "    " + arrayfitresult[ii];
                // arrayfitresult содержит инфо с фит функции

            }

            // выбрать хромосомы для срещевания
            //arraymix содержит хромосомы для скрещевания
            string[] arraymix = new string[ps_v];
            int mz = 0;
            for (ii = 0; ii < array.Length; ii = ii + 1)
            {
                double sk = rand.NextDouble();
                if (sk < 0.7)
                {
                    arraymix[mz] = array[ii];
                    result.Text = result.Text + arraymix[mz] + "   ";

                    mz = mz + 1;
                }
            }
            //int skres = 3;
            //int skres2 = 8;
            int skres = rand.Next(2,10);
            int skres2 = rand.Next(skres, 11);
            random1.Text = random1.Text + skres;
            random2.Text = random2.Text + skres2;
            char[] chars;
            char[] chars2;
            char[] mutation;
            char tempo;
            char tempo2;
            string str;
            string str2;
            string replace_part = "";
            string replace_part2 = "";


            for (ii = 0; ii < array.Length; ii = ii + 1)
            {
                arlist.Add(array[ii]);
            }

            // надо конвертнуть каждую из хромосом в массив чар иначе не понятно как поменять значения в C#
            ii = 0;
            while ((ii < arraymix.Length) && (arraymix[ii] is not null) && (arraymix[ii + 1] is not null))

            {
                str = arraymix[ii];
                chars = str.ToCharArray();

                str2 = arraymix[ii + 1];
                chars2 = str2.ToCharArray();

                for (a = skres; a < skres2 + 1; a = a + 1)
                {
                    replace_part = replace_part + chars[a];
                    replace_part2 = replace_part2 + chars2[a];
                }
                str = str.Remove(skres, skres2 - skres + 1);
                str = str.Insert(skres, replace_part2);
                str2 = str2.Remove(skres, skres2 - skres + 1);
                str2 = str2.Insert(skres, replace_part);

                arlist.Add(str);
                arlist.Add(str2);

                str = "";
                str2 = "";
                replace_part = "";
                replace_part2 = "";


                ii = ii + 2;
            }

            /* 
                for (a = skres; a < skres2; a = skres2 + 1)
                {
                    tempo = chars[a];
                    tempo2 = chars2[a];
                    chars[a] = tempo2;
                    chars2[a] = tempo;
                }

                //chars = str.ToCharArray(skres,skres2);
                arraymix[ii] = chars.ToString();
                arraymix[ii + 1] = chars2.ToString();
                resultfunction.Text = resultfunction.Text + arraymix[0] + "   " + arraymix[1] + "   ";
                ii = ii + 2;*/

            // надо конвернтнуть лист в array

            //string[] array = new string[ps_v];
            string[] stringarray = new string[arlist.Count];

            for (ii = 0; ii < arlist.Count; ii = ii + 1)
            {
                    

                   stringarray[ii] = arlist[ii].ToString();
                resultfunction.Text = resultfunction.Text + "    " + stringarray[ii];
            }
                arlist.Clear();



            //zdesj proishodit sboi pvidawij k pojavlenie system_object
            for (int mm = 0; mm < stringarray.Length; mm = mm + 1)
            {

                mutation = stringarray[mm].ToCharArray();
                for (bb = 0; bb < mutation.Length; bb = bb + 1)
                {
                    randmut = rand.NextDouble();
                    if (randmut < 0.1)
                    {
                        string peremen = mutation[bb].ToString();
                        int z = int.Parse(peremen);
                        if (z == 0)
                        {
                            peremen = "1";
                            mutation[bb] = '1';
                            stringarray[mm] = new string(mutation);

                        }
                        if (z == 1)
                        {
                            peremen = "0";
                            mutation[bb] = '0';
                            stringarray[mm] = new string(mutation);
                        }
                    }

                }

            }





            //resultfunction.Text = resultfunction.Text + "  ";

            //resultfunction.Text = resultfunction.Text + "    " + stringarray[ii];
            // arrayfitresult содержит инфо с фит функции



            //


            //string xfunction;

            //xfunction = function.Text;
            // functioninres.Content = xfunction.ToString();



            //int y;
            //x = int.Parse(textbox1.Text);
            //y = int.Parse(textbox2.Text);
            //if (x > y) {
            //  x = x + y;
            //result.Content = x;
            //

            for (ii = 0; ii < stringarray.Length; ii = ii + 1)
            {

                result_after__mutation.Text = result_after__mutation.Text + "    " + stringarray[ii];
            }

            double[] arrayfitresultaftermutation = new double[stringarray.Length];
            for (ii = 0; ii < stringarray.Length; ii = ii + 1)
            {
                fittest = (Convert.ToInt32(stringarray[ii], 2)) / 256;

                arrayfitresultaftermutation[ii] = (float)(Math.Pow(fittest, 3) - 15 * Math.Pow(fittest, 2) + (7 * fittest) + 1) / 10;
                fittestbox.Text = fittestbox.Text + "    " + arrayfitresultaftermutation[ii];


                // arrayfitresult содержит инфо с фит функции

            }

              

                ii = 0;
            int solution = 0;

                string[] arraynewpopulation = new string[ps_v];
                while (ii < arrayfitresultaftermutation.Length - 1)
            {
                double champ1 = arrayfitresultaftermutation[ii];
                double champ2 = arrayfitresultaftermutation[ii + 1];
                if (champ1 > champ2)
                {
                        arraynewpopulation[solution] = stringarray[ii];
                }
                else
                {
                        arraynewpopulation[solution] = stringarray[ii+1]; ;
                }
                ii = ii + 2;
                    solution = solution + 1;

            }


            ii = 0;
                for (int fin=0; fin<arraynewpopulation.Length; fin=fin+1)
            {
                    double champ1 = arrayfitresultaftermutation[ii];
                    double champ2 = arrayfitresultaftermutation[ii + 1];
                    if (arraynewpopulation[fin] == null)
                    {

                        if (champ1 > champ2)
                        {
                            arraynewpopulation[fin] = stringarray[ii + 1];
                        }
                        else
                        {
                            arraynewpopulation[fin] = stringarray[ii];
                        }
                    }
                }

                /*while (arraynewpopulation.Length < (ps_v))
                {
                    double champ1 = arrayfitresultaftermutation[ii];
                    double champ2 = arrayfitresultaftermutation[ii + 1];
                    if (champ1 > champ2)
                    {
                            arraynewpopulation[solution] = stringarray[ii+1];
                        }
                    else
                    {
                            arraynewpopulation[solution] = stringarray[ii];
                        }
                    ii = ii + 2;
                    solution = solution + 1;
                    }
                */


                array = arraynewpopulation;
                
                
                

        }
            for (ii = 0; ii < array.Length; ii = ii + 1)
            {

                new_generation.Text = new_generation.Text + "    " + array[ii];
            }

        }
        static void Changechararray(char[] number1, char[] number2)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
